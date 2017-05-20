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


		List<TournamentMatch>	m_arena_matches = new List<TournamentMatch>();



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



		public int GetNumStages()
		{
			return m_arena_matches.Count;
		}


		public string GetID()
		{
			return m_id;
		}

		public void SetId(string id) {
			m_id = id;
		}

		public string GetName()
		{
			return m_name;
		}

		public void SetName(string name) {
			m_name = name;
		}

		public TournamentMatch GetArenaMatch(int index)
		{
			return m_arena_matches[index-1];
		}

		public int	GetLevel()
		{
			return	m_level;
		}

		public void SetLevel(int level) {
			m_level = level;
		}

		public int	GetBuyIn()
		{
			return	m_buy_in;
		}

		public void SetBuyIn(int buyIn) {
			m_buy_in = buyIn;
		}

		public int	GetPayOutCoins()
		{
			return	m_payout_coins;
		}

		public void SetPayOutCoins(int payout) {
			m_payout_coins = payout;
		}


	
		public List<TournamentMatch> Arena_matches {
			get {
				return m_arena_matches;
			}
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
	}
}