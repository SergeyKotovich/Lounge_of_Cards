using UnityEngine;

namespace Player
{
    public class CardPositionController
    {
        private readonly Grid _grid;
        private readonly Vector3Int _playerGridOffset;

        public CardPositionController(Grid grid, Vector3Int playerGridOffset)
        {
            _playerGridOffset = playerGridOffset;
            _grid = grid;
        }

        public void SetPositionCard(Card card, int currentCountCards)
        {
            var cardPositionX = currentCountCards;
            var worldPosition = _grid.CellToWorld(_playerGridOffset + new Vector3Int(cardPositionX, 0, 0));
            card.transform.position = worldPosition;
        }
        public void SetRotationCard(Card card)
        {
            card.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }

        
    }
}