using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
	public class Game
	{
		public int warCount = 0;
		public Deck tableDeck = new Deck();
		public Deck WarDeck = new Deck();
		List<Gamer> Gamers = new List<Gamer>();
		private  int numberofCardWhenWar = 0;
		private int limittoNWars = 0;

		public   void ShowInstructions()
		{
			Console.WriteLine("THIS IS THE WAR CARD GAME");
			Console.WriteLine("After Shuffle the Card Maze and divide it between two players");
			Console.WriteLine("Each player Drops a card up on the table");
			Console.WriteLine("If your card is higger you won the round and get all the cards from the table");
			Console.WriteLine("If your card is same value.Drop 1 or 5 cards on the table down and then one up");
			Console.WriteLine("If your card is higger you won all the Cards");
			Console.WriteLine("you are the winner if let your oponent without Cards");
			Console.WriteLine("   ");
			Console.WriteLine("* * * THIS IS THE WAR CARD GAME * * *");
		}

		public void SetParams(int n,int limit)
		{
			numberofCardWhenWar = n;
			limittoNWars = limit;
		}
		public void Divide(Deck Thedeck,List<Gamer> gamers)
		{
			int n = 1;
			foreach (Card c in Thedeck.deck)
			{
				gamers[n].playerDeck.AddCard(c);
				if (n == 0)
					n = 1;
				else
					n = 0;

			}
		}
		/// <summary>
		/// Check if both Cards on the table are equals
		/// </summary>
		/// <param name="one"></param>
		/// <param name="two"></param>
		internal bool AreSame(Card one, Card two)
		{
			if (one.valueint == two.valueint)
			{
				return true;
			}
			else
				return false;
		}
		/// <summary>
		/// Review which Card has higher Value
		/// </summary>
		/// <param name="one"></param>
		/// <param name="two"></param>
		public void CheckValue(Gamer one, Gamer two)
		{
			var IsWar = AreSame(one.CurrentCard, two.CurrentCard);
			if (IsWar)
			{
				Console.WriteLine("");
				Console.WriteLine("* * * * * There is a War * * * * * *");
				warCount++;
				Console.WriteLine("Players Trow  Cards Down");
				one.TakeTurnWar(numberofCardWhenWar,false);
				two.TakeTurnWar(numberofCardWhenWar, false);
				Console.WriteLine("");
			}
			else
			{
				
				if (one.CurrentCard.valueint > two.CurrentCard.valueint)
				{
					Console.WriteLine("{0} Got Round!", one.player);
					GetTable(one);
				}
				else
				{
					Console.WriteLine("{0} Got Round!",two.player);
					
					GetTable(two);
				}
			}
			//Console.ReadKey();
		}
		//Get the total numbers pf card in Table
		/// <summary>
		/// Remove Card from table and add to  the very begining of the Hand deck"
		/// </summary>
		/// <param name="RoundWinner"></param>
		public void GetTable(Gamer RoundWinner)
		{
		//	Console.WriteLine("You Won " + tableDeck.deck.Count());
			while  (tableDeck.deck.Count>0)
			{
				int i = tableDeck.deck.Count - 1;
				Card c = tableDeck.deck[i];
				RoundWinner.playerDeck.deck.Insert(0, c);
				//.AddCard(c);
				tableDeck.deck.Remove(c);
				i--;

			}
			
		}
		/// <summary>
		///  Check if its  a Winner
		/// </summary>
		/// <param name="Gamers"></param>
		public void GetWinner(List<Gamer>  Gamers)
		{
			var w = 0;
			Console.WriteLine("THE GAME IS OVER");
			if (Gamers[0].playerDeck.deck.Count() > Gamers[1].playerDeck.deck.Count())
			{
				Console.WriteLine("Gamer 1 WON THIS GAME");
				w = 0;
			}
			else
			{
				Console.WriteLine("Gamer 2 WON THIS GAME");
				w = 1;
			}
			Console.WriteLine("Congratulation " + Gamers[w].player + "!");
			Console.WriteLine("Number of Wars:{0}", warCount) ;
		}
		}
	}


