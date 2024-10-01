using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class CardDealer : MonoBehaviour
{
    [SerializeField] private Deck _deck;
    private List<Player.Player> _players;
    private ITrump _turnManager;

    [Inject]
    public void Construct(List<Player.Player> players, ITrump turnManager)
    {
        _turnManager = turnManager;
        _players = players;
    }

    public void DealCards()
    {
        foreach (var player in _players)
        {
            while (!player.IsHandFull())
            {
                var card = _deck.GetCard();
                player.AddCard(card);
            }
        }
        SetTrumpCard();
    }

    private void SetTrumpCard()
    {
        var trump = _deck.GetCard();
        trump.transform.position = transform.position;
        trump.transform.rotation = Quaternion.Euler(0, -90, 90);
        _turnManager.SetTrump(trump);
    }
}