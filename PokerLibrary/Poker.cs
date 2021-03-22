using PokerLibrary.Models;
using System;
using System.Collections.Generic;

namespace PokerLibrary
{
    public static class Poker
    {
        public static string evaluateDeck(List<Card> cards)
        {
            if (Eval.isPair(cards))
                return Hand.pair.ToString().ToUpper();
            else if (Eval.isTwoPair(cards))
                return Hand.twoPair.ToString().ToUpper();
            else if (Eval.isThreeOfAKind(cards))
                return Hand.threeOfAKind.ToString().ToUpper();
            else if (Eval.isStraight(cards))
                return Hand.straight.ToString().ToUpper();
            else if (Eval.isFlush(cards))
                return Hand.flush.ToString().ToUpper();
            else if (Eval.isFullHouse(cards))
                return Hand.fullHouse.ToString().ToUpper();
            else if (Eval.isFourOfAKind(cards))
                return Hand.fourOfAKind.ToString().ToUpper();
            else if (Eval.isStraightFlush(cards))
                return Hand.straightFlush.ToString().ToUpper();
            else if (Eval.isRoyalFlush(cards))
                return Hand.royalFlush.ToString().ToUpper();
            else
                return Hand.highCard.ToString().ToUpper();
        }
    }
}
