using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace memory.models
{
	/// <summary>
	/// Manages the table and holds a reference to the players models, to the thrown on the table cards and to all the bids.
	/// </summary>
	public class Table
	{
		
		List<Player> m_players = new List<Player> ();
		int			m_rows;
		int 		m_columns;

		Card[,]	m_cards;


		public Table (int row, int column)
		{
			m_rows = row;
			m_columns = column;
			m_cards = new Card[m_rows,m_columns];

		}

		public void ReplacePlayer (int index, Player player)
		{
			m_players [index] = player;
		}

		public void AddPlayer (Player player)
		{
			m_players.Add (player);  
		}

		public Player GetPlayer (int index)
		{
			return m_players [index];
		}


		public Card GetTableCard (int row,int column)
		{
			return m_cards [row,column];
		}

	}

}