using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace memory.models
{

	public class ActiveTournament 
	{

		int 						m_curr_stage;
		
		Tournament						m_tournament;
		bool						m_tournament_bought;

		public event Action<int> OnStageChange;
		public event Action OnBought;
		public event Action<string> OnBoosterUsed;

		public ActiveTournament ()
		{
		}

		public ActiveTournament(Tournament tournament)
		{
			m_tournament = tournament;
		}



		public bool GetBought()
		{
			return m_tournament_bought;
		}



		public void SetTournament(Tournament tournament)
		{
			m_tournament = tournament;

		}

		public Tournament GetArena()
		{
			return m_tournament;
		}

		public TournamentMatch GetCurrArenaMatch()
		{
			return m_tournament.GetArenaMatch(m_curr_stage);
		}
		public int GetCurrStage()
		{
			return m_curr_stage;
		}

		public void SetCurrStage(int curr_stage)
		{
			m_curr_stage =curr_stage;
			if(OnStageChange!=null)
				OnStageChange(m_curr_stage);
		}


	}
}