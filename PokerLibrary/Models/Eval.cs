using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary.Models
{
    public enum Hand
    {
        royalFlush = 1,
        straightFlush,
        fourOfAKind,
        fullHouse,
        flush,
        straight,
        threeOfAKind,
        twoPair,
        pair,
        highCard
    }
    public class Eval
    {

        public static bool isPair(List<Card> cards)
        {
            var occ = getRankOcuurences(cards);
            if (occ.Count == 4)
                return true;
            else
                return false;
        }
        public static bool isTwoPair(List<Card> cards)
        {
            var occ = getRankOcuurences(cards);
            if (occ.Count == 3 && checkBins(occ) == 2)
                return true;
            else
                return false;
        }
        public static bool isThreeOfAKind(List<Card> cards)
        {
            var occ = getRankOcuurences(cards);
            if (occ.Count == 3 && checkBins(occ) == 1)
                return true;
            else
                return false;
        }

        public static bool isFourOfAKind(List<Card> cards)
        {
            var occ = getRankOcuurences(cards);
            if (occ.Count == 2 && checkBins(occ) == 1)
                return true;
            else
                return false;
        }

        public static bool isFullHouse(List<Card> cards)
        {
            var occ = getRankOcuurences(cards);
            if (occ.Count == 2 && checkBins(occ) == 2)
                return true;
            else
                return false;
        }

        public static bool isFlush(List<Card> cards)
        {
            if (getSuitsFound(cards) == 1 && isDiffOne(cards) == false)
                return true;
            else
                return false;
        }

        public static bool isStraight(List<Card> cards)
        {
            if (isDiffOne(cards) == true && getSuitsFound(cards) > 1)
                return true;
            else
                return false;
        }

        public static bool isStraightFlush(List<Card> cards)
        {
            if (isDiffOne(cards) && getSuitsFound(cards) == 1 && !checkRoyalRank(cards))
                return true;
            else
                return false;
        }

        public static bool isRoyalFlush(List<Card> cards)
        {

            if (checkRoyalRank(cards) == true && getSuitsFound(cards) == 1)
                return true;
            else
                return false;
        }

        //-----------------------------Utils -------------------------------------------//
        public static int checkBins(Dictionary<Rank, int> occ)
        {
            int count = 0;
            foreach (var item in occ)
            {
                if (item.Value > 1)
                {
                    count++;
                }
            }
            return count;
        }
        //Check if difference between card ranks is one unit
        private static bool isDiffOne(List<Card> cards)
        {
            int i = 0;
            var ret = false;
            while (i < cards.Count - 1)
            {
                if ((int)cards[i + 1].rank - (int)cards[i].rank == 1)
                    ret = true;
                else
                    return false;
                i++;
            }
            return ret;
        }
        // Get number of 'key-pair values' that have a value higher than one
        private static Dictionary<Rank, int> getRankOcuurences(List<Card> cards)
        {
            var occurances = new Dictionary<Rank, int>();
            foreach (var card in cards)
            {
                if (occurances.ContainsKey(card.rank))
                {
                    occurances[card.rank] += 1;
                }
                else
                {
                    occurances[card.rank] = 1;
                }
            }
            return occurances;
        }
        // Reaturn number of suits in deck
        private static int getSuitsFound(List<Card> cards)
        {
            var occurances = new Dictionary<Suit, int>();
            var temp = "";
            int ret = 0;
            foreach (var card in cards)
            {
                if (string.IsNullOrEmpty(temp))
                {
                    ret += 1;
                    temp = card.suit.ToString();
                }
                else
                {
                    if (temp == card.suit.ToString())
                        continue;
                    else
                    {
                        ret += 1;
                    }
                }
            }
            return ret;
        }
        //Return true if hand is royal-flush else return false
        private static bool checkRoyalRank(List<Card> cards)
        {
            var ret = false;
            var royalRank = new List<Rank>{
                Rank.ten,Rank.jack,Rank.queen,Rank.king,Rank.ace
            };

            foreach (var card in cards)
                if (royalRank.Contains(card.rank))
                    ret = true;
                else
                    return false;
            return ret;
        }
    }
}
