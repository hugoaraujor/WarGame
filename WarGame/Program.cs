
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
	class Program
	{
		// War Game CArd Game
		//  Rules :http://www.bicyclecards.com/how-to-play/war/
		static void Main(string[] args)
		{
			Game Master = new Game();
			List<Gamer> Gamers = new List<Gamer>();
			Gamer Gamer = new Gamer();
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			//Start the game with a deck of Cards Shuffled
			Deck Maze = new Deck();

			Maze.filldeck();
			Console.WriteLine("This is the General Deck Before Shuffle:");
			Maze.Print();
			Maze.Shuffle();
			Console.WriteLine("This is the General Deck Shuffled:");
			Maze.Print();

			//Have two Gamers to play
			Gamer.NewGamer(Gamers);
			Gamer.NewGamer(Gamers);
			Master.Divide(Maze, Gamers);

			//Have two Deck for each player
			Console.WriteLine("Gamer 1 Has Cards:");
			Gamers[0].PrintDeck(Gamers[0].playerDeck);
			Console.WriteLine("Gamer 2 Has Cards:");

			Gamers[1].PrintDeck(Gamers[1].playerDeck);
			while (Gamers[0].playerDeck.deck.Count>0  || Gamers[0].playerDeck.deck.Count > 0)
			{ 
			   //Trow Card
			      Master.tableDeck.AddCard(Gamers[0].TakeTurn());
			      Master.tableDeck.AddCard(Gamers[1].TakeTurn());


			

				
				//Review Cards
				Master.CheckValue(Gamers[0], Gamers[1]);
		    }

			Gamers[0].PrintDeck(Gamers[0].playerDeck);
			Gamers[1].PrintDeck(Gamers[1].playerDeck);
		
			Master.tableDeck.Print();

			Console.ReadLine();

		}
	}
}
