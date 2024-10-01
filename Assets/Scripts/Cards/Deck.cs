using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private List<Card> _listCards; 
    private readonly Stack<Card> _deckCards = new();

    private void Awake()
    {
        ShuffleDeck();
        
        foreach (var card in _listCards)
        {
            _deckCards.Push(card);
        }
    }

    public Card GetCard()
    {
        return _deckCards.Pop();
    }
    
    private void ShuffleDeck()
    {
        var randomNumber = new System.Random();
        _listCards = _listCards.OrderBy(_ => randomNumber.Next()).ToList();
    }
}
