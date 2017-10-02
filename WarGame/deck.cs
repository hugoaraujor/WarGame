
using System;
using System.Collections.Generic;
using System.Linq;

namespace WarGame
{
	public class Deck
	{
		static Random rand = new Random();
		public List<Card> deck = new List<Card>();
		public List<Card> warDeck = new List<Card>();
		public Deck()
		{

		}
		public List<Card> filldeck()
		{
			foreach (string k in Card.kind)
			{
				foreach (string c in Card.cards)
				{
					Card newCard = new Card(k, c);
					deck.Add(newCard);
				}
			}
			return deck;
		}
		public void Shuffle()
		{
			var query = (from card in deck select card).Select(card => card).OrderBy(card => rand.Next()).ToList();
			deck = query;

		}
		public void Print()
		{
			foreach (Card Card in deck)

				Console.Write(Card.display + " ");
			Console.WriteLine("");

		}
		public void AddCard(Card c)
		{
			deck.Add(c);
		}



	}
}