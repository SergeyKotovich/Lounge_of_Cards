using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public int MaxCountCards { get; private set; } = 6;
        public int CurrentCountCards { get; private set; }

        [SerializeField] private Transform _playerCardsPosition;

        public bool IsHandFull()
        {
            return CurrentCountCards >= MaxCountCards;
        }

        public void SetPosition(Card card)
        {
            card.transform.SetParent(_playerCardsPosition);
            card.transform.position = Vector3.zero;
        }
    }
}