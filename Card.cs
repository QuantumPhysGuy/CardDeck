using System;

namespace CardDeck
{
    /// <summary>
    /// Class representing a simple card object.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Enumeration of available card suits.
        /// </summary>
        public enum CardSuit : Int32
        {
            Clubs = 1,
            Diamonds = 2,
            Hearts = 3,
            Spades = 4
        }

        /// <summary>
        /// Enumeration of available card numbers.
        /// </summary>
        public enum CardNumber : Int32
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        /// <summary>
        /// Gets or sets the suit of the card.
        /// </summary>
        public CardSuit Suit { get; set; }

        /// <summary>
        /// Gets or sets the number of the card.
        /// </summary>
        public CardNumber Number {get; set;}

        /// <summary>
        /// Initializes the card object.
        /// </summary>
        /// <param name="Suit">The suit of the card to initialize.</param>
        /// <param name="Number">The number of the card to initialize.</param>
        public Card(CardSuit Suit, CardNumber Number)
        {
            this.Suit = Suit;
            this.Number = Number;
        }

        public override String ToString()
        {
            return $"{this.Number} of {this.Suit}";
        }
	}

    /// <summary>
    /// Class representing a deck of cards.
    /// </summary>
	public class Deck
    {
        /// <summary>
        /// Gets or sets the list of cards available in the deck.
        /// </summary>
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Initilizes the deck object.
        /// </summary>
        /// <remarks>Initilizes the deck with 52 cards in order.</remarks>
		public Deck()
        {
            //Simple LINQ statement to give a range of suits and populate each card with that suit. Gives a total of 52 cards paired with a suit.
            this.Cards = Enumerable.Range(1, 4).SelectMany(s => Enumerable.Range(1, 13).Select(c => new Card((Card.CardSuit)s, (Card.CardNumber)c))).ToList();
        }

        /// <summary>
        /// Randomizes the order of the card objects in the Cards property.
        /// </summary>
        /// <example>
        /// Code example on how to shuffle the deck of cards.
        /// <code>
        ///     Deck deck = new Deck();
        ///     deck.ShuffleDeck();
        /// </code>
        /// </example>
        public void ShuffleDeck()
        {
            this.Cards = this.Cards.OrderBy(x => Guid.NewGuid()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <example>
        /// Code example on how to deal a card.
        /// <code>
        ///     Deck deck = new Deck();
        ///     deck.ShuffleDeck();
        ///
        ///     deck.DealCard();
        /// </code>
        /// </example>
        public Card DealCard()
        {
            Card dealtCard = Cards.First();
            this.Cards.Remove(dealtCard);

            return dealtCard;
        }

        /// <summary>
        /// Deals the whole deck of cards.
        /// </summary>
        /// <returns>A list object containing the cards dealt.</returns>
        /// <example>
        /// <code>
        ///     Deck deck = new Deck();
        ///     deck.ShuffleDeck();
        ///
        ///     deck.DealAllCards();
        /// </code>
        /// </example>
        public List<Card> DealAllCards()
        {
            List<Card> fullDeckDeal = new List<Card>();

            for (Int32 i = 0; i <= 51; i++)
            {
                fullDeckDeal.Add(this.DealCard());
            }

            return fullDeckDeal;
        }
    }
}