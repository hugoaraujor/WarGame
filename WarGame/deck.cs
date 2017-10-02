
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
		public void Divide(List<Gamer> gamers)
		{
			int n = 0;
			foreach (Card c in deck)
			{
				

				gamers[n].playerDeck.AddCard(c);
				if (n == 0)
					n = 1;
				else
					n = 0;

			}
		}
		public bool AreSame(Card one, Card two)
		{
			if (one == two)
			{
				Console.WriteLine("There is a War");
				return true;
			}
			else
				return false;
		}
		public void CheckValue(Gamer one, Gamer two)
		{
			var IsWar=AreSame(one.CurrentCard, two.CurrentCard);
			if (IsWar)
			{
				Console.WriteLine("There is a War");
				
			}
			else
			{
				if (one.CurrentCard.valueint>two.CurrentCard.valueint)
				{
					GetTable();
				}
			}
		}

		public  void GetTable()
		{
			throw new NotImplementedException();
		}
	}


}