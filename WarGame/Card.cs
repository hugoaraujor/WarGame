using System;

namespace WarGame
{
	public class Card 
	{
		public static string[] cards = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

		//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
		public static string[] kind = { "♣", "♦", "♥", "♠" };
		public string cardvalue { get; set; }
		public int valueint { get; set; }
		public string symbol { get; set; }
		public string display { get; set; }
	
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="symbolStr">Card Type</param>
		/// <param name="Cardv">Card Value</param>
		public Card(string symbolStr, string Cardv)
		{
	
			this.cardvalue = Cardv;
			this.symbol = symbolStr;
			this.display = this.cardvalue + " " + this.symbol;
			valueint = GetValue(Cardv);
		}
	
		//get numeric value from Cards Function
		public int GetValue(string cardvalue)
		{
			var letters = "JQK";

			if (cardvalue == "A")
				valueint = 13;
			else
			{
				if (letters.IndexOf(cardvalue) > -1)
				{ valueint = letters.IndexOf(cardvalue) + 11; }
				else
				{ valueint = Convert.ToInt16(cardvalue); }
			}
			return valueint;
		}
	}
}