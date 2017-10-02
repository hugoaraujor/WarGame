
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			//Start the game with a deck of Cards Shuffled
			Deck Maze = new Deck();
		    Maze.Shuffle();
			Console.WriteLine("This is the General Deck:")
			Maze.Print();
			//Have to Gamers to play

			//divide between gamers
			Deck DeckPlayer1 = new Deck();
			Deck DeckPlayer2 = new Deck();
			Console.ReadLine();
			

	}
	}
}
