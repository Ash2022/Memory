using UnityEngine;
using System.Collections;
using System;

namespace memory.models
{
	public class SingleMatch : Match 
	{
		PlayingMode		m_playing_mode;
		int				m_collectable_total;
		int				m_game_played;
		int				m_buy_in;

		int 			m_level;

		bool			m_claimed=false;
		int 			m_image_index;


		public event Action<int> OnGamesPlayed;

		public SingleMatch() {
			
		}

		public SingleMatch(string table_id,int level,int collectable_total, int buy_in,int high_points, int low_points,int payout_coins,int payout_gems,float bid_delay,float play_delay)
		{
			m_table_id = table_id;
			m_buy_in = buy_in;
			m_payout_coins = payout_coins;
			m_payout_gems = payout_gems;
			m_level = level;
			m_turn_play_time = play_delay;
			m_collectable_total = collectable_total;
			m_game_played = 0;

		}

		public override int	GetBuyIn()
		{
			return	m_buy_in;
		}

		public override PlayingMode Playing_mode {
			get {
				return m_playing_mode;
			}
			set{ 
				m_playing_mode = value;
			}
		}

	}
}