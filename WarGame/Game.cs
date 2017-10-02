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
		public int NumberofCardWhenWar = 1;
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
			var IsWar = AreSame(one.CurrentCard, two.CurrentCard);
			if (IsWar)
			{
				Console.WriteLine("There is a War");
				one.TakeTurnWar(NumberofCardWhenWar);
				one.TakeTurnWar(NumberofCardWhenWar);
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
		}

		public void GetTable(Gamer RoundWinner)
		{
			foreach (Card c in tableDeck.deck)
			{
				RoundWinner.playerDeck.AddCard(c);

			}
			tableDeck.warDeck = new List<Card>();
		}
	}
}

