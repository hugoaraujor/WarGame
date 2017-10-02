
using System;
using System.Collections.Generic;
using System.Linq;

namespace WarGame
{

	public class Card
	{
		public static string[] cards = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

		//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
		public static string[] kind = { "♣", "♦", "♥", "♠" };


		public int id { get; set; }
		public string cardvalue { get; set; }
		public string symbol { get; set; }
		public string display { get; set; }
		internal int index { get; set; }

		public Card(string symbolStr, string Cardv)
		{
			index++; ;
			this.id = index;
			this.cardvalue = Cardv;
			this.symbol = symbolStr;
			this.display = this.cardvalue + " " + this.symbol;
		}


	}
	public class Gamer
	{

		public Gamer(string name)
		{
			
			player = name;

		}
		public static Deck deck { get; set; }
	    public string player { get; set; }
		public List<Gamer> Gamers = new List<Gamer>();

		public void Print()
		{
			foreach (Gamer g in Gamers)
				Console.WriteLine(g.player);
		}
		public void PrintDeck(Deck deck)
		{
			deck.Print();
		}
		public void GetName()
		{
			 Console.WriteLine("Player {0} ");
			string nameValue = Console.ReadLine();
			Gamer gamer = new Gamer(nameValue);
			
		}
	}
	public class Deck
	{
		static Random rand = new Random();
		public static List<Card> deck = new List<Card>();
	
		public Deck()
		{
			deck = filldeck();
		}
		public static List<Card> filldeck()
		{
		    foreach (string k in Card.kind)
			{
				foreach (string c in Card.cards)
				{
					Card newCard =  new Card(k,c );
					deck.Add(newCard);
				}
			}
			return deck;
		}
		public  void Shuffle()
		{
			var query = (from card in deck select card).Select(card=>card).OrderBy(card=>rand.Next()).ToList();
			return ;
		}
		public  void Print()
		{
			foreach (Card Card in deck)
				Console.Write(Card.display + " ");

		}

		
	}
	

}