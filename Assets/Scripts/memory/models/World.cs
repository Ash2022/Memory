using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace memory.models
{
	public class World 
	{
		string 							m_id;
		string 							m_name;

		Dictionary<string,SingleMatch>	m_single_matches = new Dictionary<string, SingleMatch>();	
		Tournament						m_tournament;

		public World() {
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

		public void SetTournament(Tournament tournament)
		{
			m_tournament = tournament;
		}

		public Tournament GetTournament()
		{
			return m_tournament;
		}

		public void AddSingleMatch(SingleMatch single_match)
		{
			m_single_matches.Add (single_match.GetTableID(), single_match);
		}

		public SingleMatch GetSingleMatch(string key)
		{
			SingleMatch temp;

			m_single_matches.TryGetValue (key, out temp);

			return temp;
		}

		public int GetSingleMatchCount()
		{
			return m_single_matches.Count;
		}


		public Dictionary<string, SingleMatch> Single_matches {
			get {
				return m_single_matches;
			}
		}

	

	}
}