using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public struct Card: IComparable<Card>
    {
        public String value;
        public String suit;
        public int intValue;

        public Card(String value, String suit)
        {
            this.value = value;
            this.suit = suit;
            this.intValue = 0;
        }

        public int CompareTo(Card other)
        {
            this.intValue = ToInt(value);
            int otherValueInt = ToInt(other.value);

            if (intValue > otherValueInt)
            {
                return 1;
            } else if (otherValueInt > intValue)
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
                    return Convert.ToInt32(stringValue);
            }

        }
    }
}