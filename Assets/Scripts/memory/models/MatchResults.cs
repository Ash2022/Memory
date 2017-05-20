using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace memory.models
{

public class MatchResults 
	{


		public enum Positions
		{
			West,North,East,South
		}

	
		private int	m_round_number;

		PlayerMatchResults[] players_round_results;

		public MatchResults (PlayerMatchResults[] players_round_results,int round_number)
		{
			this.players_round_results = players_round_results;
			m_round_number = round_number;
		}

		public MatchResults (int num_players)
		{
			players_round_results = new PlayerMatchResults[num_players];
		}

		public void SetRoundNumber(int round_number)
		{
			m_round_number = round_number;
		}

	
		public void SetResults(Positions position,PlayerMatchResults players_results)
		{
			if (position > Positions.South)
				position -= 4;

			players_round_results[(int)position] = players_results;
		}

		public int GetRoundNumber()
		{
			return	m_round_number;
		}

		public PlayerMatchResults GetResults(Positions position)
		{
			if (position > Positions.South)
				position -= 4;

			return players_round_results [(int)position]; 
		}

		public bool	HasResults()
		{
			return players_round_results[0]!=null;
		}

	}

}