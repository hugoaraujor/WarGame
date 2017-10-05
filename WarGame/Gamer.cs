
using System;
using System.Collections.Generic;

namespace WarGame
{
	public class Gamer 
	{
		public Deck playerDeck { get; set; }
		public string player { get; set; }
		public List<Gamer> gamers { get; set; }
		public Card CurrentCard { get; set; }
		
		public List<Gamer> NewGamer(List<Gamer> Gamers)
		{
			gamers = Gamers;
			GetName(gamers);
			return gamers;
		}
		
		public void Print()
		{
			foreach (Gamer g in gamers)
				Console.WriteLine(g.player);
		}

		public void PrintDeck(Deck PlayerDeck)
		{
			PlayerDeck.Print();
		}

		public List<Gamer> GetName(List<Gamer> Gamers)
		{
			int playersCount = gamers.Count + 1;
			if (playersCount <= 2)
			{
				Console.WriteLine("Enter {0} Player Name ", playersCount);
				string nameValue = Console.ReadLine();
				var newdeck = new Deck();
				var aux = new Gamer() { player = nameValue, playerDeck = newdeck };
				gamers.Add(aux);
			}
			else
			{
				Console.WriteLine("You have two Players already");
			};
			return gamers;
		}
		public Card TakeTurn(bool show)
		{
			var item = playerDeck.deck.Count-1 ;
			if (item >= 0)
			{
				CurrentCard = playerDeck.deck[item];
				if (show)
				Console.Write("   [" + CurrentCard.display + "]     ");
				else
					Console.Write("   [█]     ");
				this.playerDeck.deck.Remove(CurrentCard);
			}
			return CurrentCard;
		}
		public Card TakeTurnWar(int n,bool show)
		{
			for (int i = 0; i < n; i++)
			{
				TakeTurn(show);
				this.playerDeck.deck.Remove(CurrentCard);
			}
			return CurrentCard;
		}
	}
}