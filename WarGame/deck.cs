
using System;
using System.Collections.Generic;
using System.Linq;

namespace WarGame
{
	public class Deck : IDeck
	{
		static Random rand = new Random();
		public List<Card> deck = new List<Card>();
		public List<Card> warDeck = new List<Card>();

		public Deck()
		{

		}

		//Compose the maze with all the Cards in order for symbol
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

		//Shuffle the Cards using Linq query
		public void Shuffle()
		{
			var query = (from card in deck select card).Select(card => card).OrderBy(card => rand.Next()).ToList();
			deck = query;

		}

		//Print The Maze
		public void Print()
		{
			foreach (Card Card in deck)
			{
				Console.Write(Card.display + " ");
			}
			Console.WriteLine("");

		}

		internal  void AddCard(Card c)
		{
			deck.Add(c);
		}
	}
}