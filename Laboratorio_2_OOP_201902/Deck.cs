using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Deck
    {
        private List<Card> DeckCards;
        

        public Deck()
        {

        }

        public List<Card> DeckCards { get => deckCards; set => deckCards = value; }
        

        public void AddDeckCard(Card deckCards) { throw new NotImplementedException(); }
      
        public void DestroyDeckCard(int cardId) { throw new NotImplementedException(); }
        
        public void Shuffle() { 
            throw new NotImplementedException();
        }
    }
}
