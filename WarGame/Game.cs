using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
	public class Game
	{
		public Deck tableDeck = new Deck();
		public Deck WarDeck = new Deck();
		List<Gamer> Gamers = new List<Gamer>();
		public int NumberofCardWhenWar = 0;

		public void Divide(Deck Thedeck,List<Gamer> gamers)
		{
			int n = 0;
			foreach (Card c in Thedeck.deck)
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
			if (one.valueint == two.valueint)
			{
				Console.WriteLine("There is a War");
				return true;
			}
			else
				return false;
		}
		public void CheckValue(Gamer one, Gamer two)
		{
			var IsWar = AreSame(one.CurrentCard, two.CurrentCard);
			if (IsWar)
			{
				Console.WriteLine("There is a War");
				one.TakeTurnWar(NumberofCardWhenWar);
				two.TakeTurnWar(NumberofCardWhenWar);
			}
			else
			{
				
				if (one.CurrentCard.valueint > two.CurrentCard.valueint)
				{
					Console.WriteLine("Gamer 0 Won this Round!");
					GetTable(one);
				}
				else
				{
					Console.WriteLine("Gamer 1 Won this Round!");
					
					GetTable(two);
				}
			}
			Console.ReadKey();
		}

		public void GetTable(Gamer RoundWinner)
		{
			Console.WriteLine("You Won " + tableDeck.deck.Count());
			while  (tableDeck.deck.Count>0)
			{
				int i = tableDeck.deck.Count - 1;
				Card c = tableDeck.deck[i];
				RoundWinner.playerDeck.AddCard(c);
				tableDeck.deck.Remove(c);
				i--;

			}
			
		}

		public void GetWinner(List<Gamer>  Gamers)
		{
			Console.WriteLine("THE GAME IS OVER");
			if (Gamers[0].playerDeck.deck.Count() > Gamers[1].playerDeck.deck.Count())
				Console.WriteLine("Gamer 0 WON THIS GAME");
				else
				Console.WriteLine("Gamer 0 WON THIS GAME");
			Console.WriteLine("Congratulation " + Gamers[0].player + "!");

		}
		}
	}


