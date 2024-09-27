using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [field: SerializeField] public List<Card> ListCards { get; private set; }

    public Card GetCard()
    {
      var card =  ListCards.LastOrDefault();
      return card;
    }
}