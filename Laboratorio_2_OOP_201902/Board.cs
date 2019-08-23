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



        //Metodos
        public void AddCombatCard(int playerId, CombatCard combatCard)
        {
            if (combatCard.Type == "melee")
            {
                meleeCards[playerId].Add(combatCard);
            }
            else if (combatCard.Type == "range")
            {
                rangeCards[playerId].Add(combatCard);
            }
            else
            {
                longRangeCards[playerId].Add(combatCard);
            }
            
        }
        public void AddSpecialCard(SpecialCard specialCard, int playerId = -1, string buffType = null)
        {
            if (specialCard.Type == "captain")
            {
                if (playerId == 0 || playerId == 1)
                {
                    captainCards[playerId] = specialCard;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else if (specialCard.Type == "weather")
            {
                weatherCards.Add(specialCard);
            }
            else
            {
                if (buffType != null)
                {
                    if (playerId == 0 || playerId == 1)
                    {
                        if (buffType == "melee")
                        {
                            specialMeleeCards[playerId] = specialCard;
                        }
                        else if (buffType == "range")
                        {
                            specialRangeCards[playerId] = specialCard;
                        }
                        else
                        {
                            specialLongRangeCards[playerId] = specialCard;
                        }
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }   
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public void DestroyCombatCards()
        {
            this.meleeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
            this.rangeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
            this.longRangeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
        }
        public void DestroySpecialCards()
        {
            this.specialMeleeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.specialRangeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.specialLongRangeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.weatherCards = new List<SpecialCard>();
        }
        public int[] GetMeleeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas melee y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i=0; i < 2; i++)
            {
                foreach (CombatCard meleeCard in meleeCards[i])
                {
                    totalAttack[i] += meleeCard.AttackPoints;
                }
            }
            return totalAttack;
            
        }
        public int[] GetRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas range y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                foreach (CombatCard rangeCard in rangeCards[i])
                {
                    totalAttack[i] += rangeCard.AttackPoints;
                }
            }
            return totalAttack;
        }
        public int[] GetLongRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas longRange y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                foreach (CombatCard longRangeCard in longRangeCards[i])
                {
                    totalAttack[i] += longRangeCard.AttackPoints;
                }
            }
            return totalAttack;
        }
    }
}
