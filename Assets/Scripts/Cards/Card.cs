using UnityEngine;

public class Card : MonoBehaviour
{
    [field: SerializeField] public Suit CardSuit { get; private set; }
    [field: SerializeField] public Rank CardRank { get; private set; }
    
}