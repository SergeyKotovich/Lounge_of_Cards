using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class TurnManager : MonoBehaviour, ITrump
{
    public Card Trump { get; private set; }

    private List<Player.Player> _players;
    private Player.Player _firstPlayer;
    private Card _lowestTrump;

    [Inject]
    public void Construct(List<Player.Player> players)
    {
        _players = players;
    }

    public void SetTrump(Card trump)
    {
        Trump = trump;
        DecideFirstTurn();
    }

    private void DecideFirstTurn()
    {
        _firstPlayer = null;
        _lowestTrump = null;

        foreach (var player in _players)
        {
            foreach (var card in player.Cards)
            {
                if (card.CardSuit == Trump.CardSuit)
                {
                    if (_lowestTrump == null || card.CardRank < _lowestTrump.CardRank)
                    {
                        _lowestTrump = card;
                        _firstPlayer = player; 
                    }
                }
            }
        }

        if (_firstPlayer != null)
        {
            Debug.Log($"Первым ходит игрок: {_firstPlayer.name} с картой {_lowestTrump}");
        }
        else
        {
            Debug.Log("Не найдено козырных карт.");
        }
    }
}