using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerAttackController : MonoBehaviour
    {
        public int AttackingCardsCount { get; private set; }
        
        [SerializeField] private Vector3Int playerGridOffset;
        private GameObject _cardTable;
        private Grid _grid;

        public void Initialize(GameObject cardTable, Grid grid)
        {
            _grid = grid;
            _cardTable = cardTable;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                if (hitInfo.collider.CompareTag(GlobalConstants.CARD_TAG))
                {
                    hitInfo.transform.SetParent(_cardTable.transform);
                    var cardPositionX = AttackingCardsCount;
                    var worldPosition = _grid.CellToWorld(playerGridOffset + new Vector3Int(cardPositionX, 0, 0));
                    hitInfo.transform.DOMove(worldPosition, 1);
                    AttackingCardsCount++;
                }
            }
        }
    }
}