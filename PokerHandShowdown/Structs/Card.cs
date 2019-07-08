using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public struct Card: IComparable<Card>
    {
        public String value;
        public String suit;

        public Card(String value, String suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public int CompareTo(Card other)
        {
            int valueInt = ToInt(value);
            int otherValueInt = ToInt(other.value);

            if (valueInt > otherValueInt)
            {
                return 1;
            } else if (otherValueInt > valueInt)
            {
                return -1;
            } else
            {
                return 0;
            }
        }

        private int ToInt(String stringValue)
        {
            switch (stringValue)
            {
                case "A":
                    return 14;

                case "K":
                    return 13;

                case "Q":
                    return 12;

                case "J":
                    return 11;

                default:
                    return Convert.ToInt32(value);
            }

        }
    }
}