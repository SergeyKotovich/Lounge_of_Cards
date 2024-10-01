using System.Collections.Generic;

namespace Player
{
    public interface IPlayerCardsProvider
    {
        public List<Card> Cards { get; } 
    }
}