using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace memory.models
{

	public class ActiveTournament 
	{

		int 						m_curr_stage;
		
		Tournament					m_tournament;
		bool						m_tournament_bought;

		public ActiveTournament ()
		{
		}

		public ActiveTournament(Tournament tournament)
		{
			m_tournament = tournament;
		}


		public TournamentMatch GetCurrTournamentMatch()
		{
			return m_tournament.Tournament_matches[m_curr_stage];
		}
	
	}
}