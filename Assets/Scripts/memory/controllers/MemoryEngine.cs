using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using memory.models;
using System.Text;

namespace memory.controllers
{
	/// <summary>
	/// Spades engine - manages a spades game - also holds the deck
	/// </summary>
	public class MemoryEngine  
	{

		int						m_curr_nil_penalty=0;
		//deck related
		List<Card> my_deck = new List<Card>();
		List<Card> my_deckHelper = new List<Card>();

		//trick related

		public int	m_curr_player_turn;
		Table		m_table;
		ActiveMatch m_active_match;

		public int GetCurrPlayerTurn()
		{
			return m_curr_player_turn;
		}

		/// <summary>
		/// creates and shuffels a deck
		/// </summary>
		public void ShuffleDeck()
		//shuffle uses random to pick 1 of all remaining cards in a loop from a helper deck - adding to the "real" deck- until there are no more cards to pick
		{
			int temp;

			Card tempCard;
			//filling the helper deck with all the cards
			for (int i=1;i<5;i++)	//4 suits
			{
				for(int j=1;j<14;j++)	//13 cards
				{
					my_deckHelper.Add(new Card(i,j));
				}
			}

			//cleaning the current deck
			my_deck.RemoveRange(0,my_deck.Count);


			for(int k=0;k<51;k++)
			{
				temp = Random.Range(0,my_deckHelper.Count);
				tempCard = new Card(my_deckHelper[temp].Color,my_deckHelper[temp].Value);
				my_deck.Add(tempCard);
				my_deckHelper.RemoveAt(temp);
			}			

			//last card - no random
			tempCard = new Card(my_deckHelper[0].Color,my_deckHelper[0].Value);
			my_deck.Add(tempCard);
			my_deckHelper.RemoveAt(0);

		}

		/// <summary>
		/// Gets the card from deck - for dealing the cards
		/// </summary>
		/// <returns>The card from deck.</returns>
		public Card GetCardFromDeck()
		{
			Card temp;
			temp = my_deck[0];
			my_deck.RemoveAt(0);
			return	temp; 
		}


	
	}

}
