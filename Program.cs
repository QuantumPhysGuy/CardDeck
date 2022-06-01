CardDeck.Deck deck = new CardDeck.Deck();

deck.ShuffleDeck();

var c = deck.DealAllCards();

Console.WriteLine(deck.DealCard().ToString());