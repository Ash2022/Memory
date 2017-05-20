using UnityEngine;
using System.Collections;

namespace memory.models
{
	public class TournamentMatch : Match
	{

		Tournament	m_tournament;

	

		public TournamentMatch(TournamentMatch arena_match)
		{
			
			m_turn_play_time = arena_match.GetPlayDelay ();

		}

		public TournamentMatch(int high_points, int low_points,float bid_delay,float turn_delay,int pay_out_coins,int pay_out_crowns)
		{
			
			m_turn_play_time = turn_delay;

			m_payout_coins = pay_out_coins;
		}

		public TournamentMatch()
		{
		}

		public void SetTournament(Tournament tournament)
		{
			m_tournament = tournament;
		}

		public Tournament GetTournament()
		{
			return m_tournament;
		}

		public override int	GetBuyIn()
		{
			return m_tournament.GetBuyIn();
		}

		public override PlayingMode Playing_mode {
			get {
				return m_tournament.Playing_mode;
			}
			set{ 
				
			}
		}
	}
}