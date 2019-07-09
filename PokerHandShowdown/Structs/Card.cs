using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public struct Card: IComparable<Card>, IEquatable<Card>
    {
        public String value;
        public String suit;
        public int intValue
        {
            get { return ToInt(this.value); }
            set { intValue = value; }
        }

        public Card(String value, String suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public int CompareTo(Card other)
        {
            if (intValue > other.intValue)
            {
                return 1;
            }

            if (other.intValue > intValue)
            {
                return -1;
            }

            return 0;
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

        public bool Equals(Card other)
        {
            return intValue == other.intValue;
        }
    }
}