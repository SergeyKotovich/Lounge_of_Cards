using UnityEngine;
using VContainer;

public class CardDealer : MonoBehaviour
{
    [SerializeField] private Deck _deck;
    private Player.Player _player;

    [Inject]
    public void Construct(Player.Player player)
    {
        _player = player;
    }
    
    public void DealCards()
    {
        if (!_player.IsHandFull())
        {
           var card = _deck.GetCard();
           _player.SetPosition(card);
        }
    }
}
