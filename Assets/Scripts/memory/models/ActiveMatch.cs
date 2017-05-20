using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace memory.models
{
	public class ActiveMatch  {
		
		Match					m_match;
		List<MatchResults> 		m_rounds_results = new List<MatchResults>();


		public event Action<MatchResults> OnScoreChange;

		public ActiveMatch (Match match)
		{
			m_match = match;

		}



		public void	AddResults(MatchResults m_results)
		{
			m_rounds_results.Add(m_results); 

			if (OnScoreChange != null)
				OnScoreChange (m_results);
		}



		public Match GetMatch()
		{
			return	m_match;
		}

		public int	GetRoundsCount()
		{
			return m_rounds_results.Count;
		}

		public MatchResults GetRoundResult(int round_number)
		{
			return	m_rounds_results[round_number-1];
		}

		public MatchResults GetLastRoundResults()
		{
			return m_rounds_results.FindLast (i=>true);//this return the last child of the list - and it returns null if there is nothing there
		}

		public bool IsSingleMatch
		{
			get{
				return m_match.GetType() == typeof(SingleMatch);
			}
		}

	}

}