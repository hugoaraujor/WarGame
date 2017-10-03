using System.Collections.Generic;

namespace WarGame
{
	public interface IDeck
	{
		List<Card> filldeck();
		void Print();
		void Shuffle();
	}
}