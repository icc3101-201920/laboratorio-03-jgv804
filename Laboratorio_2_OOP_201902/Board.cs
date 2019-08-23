using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Board
    {
        //Constantes
        private const int DEFAULT_NUMBER_OF_PLAYERS = 2;

        //Atributos
        

        private List<SpecialCard> weatherCards;
        private Dictionary<string, List<Card>>[] PlayerCards;
        //Propiedades
        public Dictionary<string, List<Card>>[] PlayerCards
        {
            get
            {
                return this.playerCards;
            }
            set
            {
                this.PlayerCards = value;
            }
        }
        
        
        public List<SpecialCard> WeatherCards
        {
            get
            {
                return this.weatherCards;
            }
        }


        //Constructor
        public Board()
        {
          

            this.weatherCards = new List<SpecialCard>();            this.playerCards = new Dictionary<string, List<Card>>[DEFAULT_NUMBER_OF_PLAYERS];
            this.playerCards[0] = new Dictionary<string, List<Card>>();
            this.playerCards[1] = new Dictionary<string, List<Card>>();
        }



  

        public void AddCard(Card card, int PLayerid =-1, string Bufftype =null)
        {
            if (card.GetType().Name == nameof(CombatCard))
            {
                if (playerId == 0 || playerId == 1)
                {
                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        playerCards[playerId][card.Type].Add(card);
                    }

                    else
                    {
                        playerCards[playerId].Add(card.Type, new List<Card>() { card });

                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("No player id given");
                }



            }
            else
            {
                if (playerId == 0 || playerId == 1)
                {
                    if (card.GetType().Name == "captain")
                    {



                        if (PlayerCards[playerid].ContainsKey("captain"))
                        {
                            throw new Exception("captain is already set");
                        }

                        else
                        {
                            playerCards[playerId].Add(card.Type, new List<Card>() { card });
                        }
                    }

                    if (card.GetType().Name == "Buffer")
                    {
                        if (PlayerCards[PLayerid].ContainsKey(card.type + card.buffType))
                        {
                            throw new Exception("Card is already Buffed");
                        }
                        else
                        {
                            playerCards[playerId].Add(card.Type+card.buffType, new List<Card>() { card });
                        }
                    }
                   
                    if (card.GetType().Name == "Weather")
                    {
                        weatherCards.add(card);
                    }
                    else
                    {
                        throw new Exception("the special card selected does not have compatible type");
                    }



                }
                else
                {
                    throw new IndexOutOfRangeException("No player id given");

                }
                
            }
        }
       
        public void DestroyCards()
        {
            List<Card>[] captainCards = new List<Card>[DEFAULT_NUMBER_OF_PLAYERS]
            {
                new List <Card >(playerCards[0]["captain"]),
                new List <Card >(playerCards[1]["captain"])
            };

            this.weatherCards = new List<SpecialCard>();
            this.playerCards = new Dictionary<string, List<Card>>[DEFAULT_NUMBER_OF_PLAYERS];
            playerCards[0].Add("captain", captainCards[0]);
            playerCards[1].Add("captain", captainCards[1]);

        }
    
        public int[] GetAttackPoints()
        {
            int[] totalAttack = new int[] { 0, 0 };
            for (int i=0; i < 2; i++)
            {
                foreach (Card card in PlayerCards[i]["CombatCards"])
                {
                    totalAttack[i] += card.AttackPoints;
                }
            }
            return totalAttack;
            
        }
       
        
    }
}
