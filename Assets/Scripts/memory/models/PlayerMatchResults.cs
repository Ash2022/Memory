using UnityEngine;
using System.Collections;

namespace memory.models
{

public class PlayerMatchResults 
	{


		 int	m_score_round;

	
		public PlayerMatchResults ()
		{

			m_score_round = 0;


		}
	
	
		public int Score_round {
			get {
				return m_score_round;
			}
			set{
				m_score_round = value;
			}
		}



	}
}