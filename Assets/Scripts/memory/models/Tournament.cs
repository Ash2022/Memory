using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace memory.models
{
	public class Tournament 
	{
		PlayingMode		m_playing_mode;

		int				m_buy_in;
		int				m_payout_coins;
		int				m_payout_gems;
		int				m_level;
		string 			m_name;
		string 			m_id;
		int				m_num_wins;


		List<TournamentMatch>	m_tournament_matches = new List<TournamentMatch>();



		public Tournament(int buy_in,int payout_gold,int payout_gems,int level,int num_stages,string name,string id, TournamentMatch[] matches,int num_wins)
		{

			m_buy_in = buy_in;
			m_payout_coins = payout_gold;
			m_level = level;
			m_name = name;
			m_id = id;
			m_payout_gems = payout_gems;
			m_num_wins = num_wins;

		

		}

		public PlayingMode Playing_mode {
			get {
				return m_playing_mode;
			}
			set{ 
				m_playing_mode = value;
			}
		}

		public int Num_wins {
			get {
				return m_num_wins;
			}
			set{
				m_num_wins = value;
			}
		}

		public List<TournamentMatch> Tournament_matches {
			get {
				return m_tournament_matches;
			}
		}

		public int Buy_in {
			get {
				return m_buy_in;
			}
		}
	}
}