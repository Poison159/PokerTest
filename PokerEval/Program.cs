using PokerLibrary.Models;
using PokerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet
{

    class Program
    {
        static void Main(string[] args)
        {
            
            
            var cards = fiilDeck();
            var randomCards = shuffleDeck(cards,1000);
            var hand = dealHand(randomCards, 5).OrderBy(x => x.rank).ToList();
            printHand(hand);
            Console.WriteLine(Poker.evaluateDeck(hand));
            Console.ReadLine();
        }

        static void randomizePlayers(List<Card> randomCards,int index){
            int j = 0;
            while (j < index)
            {
                var myCards = dealHand(randomCards,5).OrderBy(x => x.rank).ToList();
                printHand(myCards);
                Console.WriteLine(Poker.evaluateDeck(myCards));
                j++;
            }
        }

        static List<Card> dealHand(List<Card> cards,int max) {
            var retList = new List<Card>();
            int i = 0;
            while (i < max) {
                retList.Add(cards[i]);
                cards.RemoveAt(i);
                i++;
            }
            return retList;
        }

        static List<Card> shuffleDeck(List<Card> cards,int index){
            if(index == 0)
                return cards;
            var retList = new List<Card>();
            Random rnd = new Random();
            var max = 0;
            while(cards.Count != 0){
                max = cards.Count - 1;
                int i = rnd.Next((max));
                if(cards[i] != null)
                    retList.Add(cards[i]);
                cards.RemoveAt(i);
            }
            return shuffleDeck(retList,index - 1);
        }

        static List<Card> fiilDeck(){
            var retCards = new List<Card>();
            foreach (Suit suit in (Suit[]) Enum.GetValues(typeof(Suit))){
                foreach(Rank rank in (Rank[]) Enum.GetValues(typeof(Rank))){
                    var card = new Card(suit,rank);
                    retCards.Add(card);
                }
            }
            return retCards;
        }

        static void printHand(List<Card> myCards)
        {
            Console.WriteLine("---------------------------");
            foreach (var card in myCards)
            { 
                Console.WriteLine(card.rank.ToString()  + " of "+ card.suit.ToString()+ "s");

            }
            Console.WriteLine("---------------------------------");
        }
    }
}
