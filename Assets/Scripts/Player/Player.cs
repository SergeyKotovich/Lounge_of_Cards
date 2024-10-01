using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Player
{
    public class Player : MonoBehaviour, IPlayerCardsProvider 
    {
        public int MaxCountCards { get; private set; } = 6;
        public int CurrentCountCards { get; private set; }

        public List<Card> Cards { get; private set; } = new();
        
        [SerializeField] private PlayerAttackController _playerAttackController;
        [SerializeField] private Vector3Int _playerGridOffset;
        private CardPositionController _cardPositionController;
        
        [Inject]
        public void Construct(GameObject cardTable, Grid grid)
        {
            _playerAttackController.Initialize(cardTable, grid);
            _cardPositionController = new CardPositionController(grid, _playerGridOffset);
        }

        public bool IsHandFull()
        {
            return CurrentCountCards >= MaxCountCards;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
            card.transform.SetParent(transform);
            _cardPositionController.SetPositionCard(card, CurrentCountCards);
            _cardPositionController.SetRotationCard(card);
            CurrentCountCards++;
        }
    }
}