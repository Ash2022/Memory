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

		public string GetTableID()
		{
			return m_table_id;
		}

		public void SetId(string id) {
			m_table_id = id;
		}

		public float GetPlayDelay()
		{
			return m_turn_play_time;
		}

		public void SetPlayDelay(float delay) {
			m_turn_play_time = delay;
		}

		public int	GetPayOutCoins()
		{
			return	m_payout_coins;
		}

		public void SetPayOutCoins(int payout) {
			m_payout_coins = payout;
		}

		public abstract int GetBuyIn();

		public abstract PlayingMode Playing_mode {
			get;
			set;
		}

		public string World_id {
			get {
				return m_world_id;
			}
			set {
				m_world_id = value;
			}
		}
	}
}