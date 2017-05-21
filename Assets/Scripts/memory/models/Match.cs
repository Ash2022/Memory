using UnityEngine;
using System.Collections;

namespace memory.models
{
	public abstract class Match 
	{
		protected string	m_world_id;
		protected string 	m_table_id;
		protected int		m_payout_coins;
		protected int		m_payout_gems;
		protected int 		m_payout_progress;
		protected float 	m_turn_play_time;
		protected int 		m_num_players;
		protected int		m_num_items_to_match;

	

		public abstract int GetBuyIn();

		public abstract PlayingMode Playing_mode {
			get;
			set;
		}


	}
}