
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
	class Program
	{
		// War Game Card Game
		/// Programmer: Hugo Araujo - Venezuela
		/// </summary>My Approach to a WAr Game Symulation between two players
		//  Rules :http://www.bicyclecards.com/how-to-play/war/
		static void Main(string[] args)
		{
		
			GoWar();
			Console.ReadLine();

		}

		private static void GoWar()
		{
			Game Master = new Game();
			Master.ShowInstructions();

			//change 
			/// LimittoNWars = N; //if you limit the game when got (N) wars or higher
			/// NumberofCardWhenWar = N; //number of cards to drop
			int LimittoNWars = 5;
			int NumberofCardWhenWar = 1;
			Master.SetParams(NumberofCardWhenWar, LimittoNWars);
			
			List<Gamer> Gamers = new List<Gamer>();
			Gamer Gamer = new Gamer();

			//to allow symbols of card be displayer right way
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			//Start the game with a deck of Cards Shuffled
			Deck Maze = new Deck();
			Maze.filldeck();
			Maze.Shuffle();
			
			//Maze.Print(); to print all Maze Cards Shuffled
			
			//Have two Gamers to play divide the Maze in  two parts
			Gamer.NewGamer(Gamers);
			Gamer.NewGamer(Gamers);
			Master.Divide(Maze, Gamers);
			//seeHands(Gamers);

			//Write Heading on screen
			Console.WriteLine("   " + Gamers[0].player + "    " + Gamers[1].player);

			while ((Gamers[0].playerDeck.deck.Count > 0 
				   && Gamers[1].playerDeck.deck.Count > 0 )
			    	&&(Master.warCount<LimittoNWars))
				{		
						//Trow Card and add to a Player Deck
						Master.tableDeck.AddCard(Gamers[0].TakeTurn(true));
						Master.tableDeck.AddCard(Gamers[1].TakeTurn(true));
						//Review Cards
				      Master.CheckValue(Gamers[0], Gamers[1]);
				
		     	}
			Master.GetWinner(Gamers);
			Console.WriteLine(" Wars:{0}", Master.warCount);
		}
		
		//to see each player Hands of Cards just for Testing
		static void seeHands(List<Gamer> gamers)
		{
				Console.WriteLine("Gamer 1 Has Cards:");
				gamers[0].PrintDeck(gamers[0].playerDeck);
				Console.WriteLine("Gamer 2 Has Cards:");
				gamers[1].PrintDeck(gamers[1].playerDeck);

		}
	}
	
}
