using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Xml;
using System.IO;
using SimpleJSON;


using System;

namespace memory.models
{

	public enum PlayingMode
	{
		Standard = 'S',
		SeeMyLine = 'P',
	}


	/// <summary>
	/// Manages all the models and holds a reference to the parent Table model.
	/// </summary>
	public class ModelManager : MonoBehaviour
	{
		public TextAsset m_params_json;
	
		Table m_table;
		Card m_card;
		Player m_player;

		TournamentMatch m_arena_match = null;
		Dictionary<string,World> m_worlds;

		ActiveMatch m_active_match;

		Dictionary<string,ActiveTournament>	m_active_arenas;

		int m_curr_match;

		User m_user;

		static ModelManager m_instance;

		public static ModelManager 		Instance {
			get {

				if (m_instance == null) {
					ModelManager manager = GameObject.FindObjectOfType<ModelManager> ();
					m_instance = manager.GetComponent<ModelManager> ();
				}
				return m_instance;
			}
		}

		public void SetUser (User user)
		{
			m_user = user;
		}

		public User GetUser ()
		{
			return m_user;
		}



		public World GetWorld (string key)
		{
			return m_worlds [key];
		}

		public int GetNumWorlds ()
		{
			return m_worlds.Count;
		}


		public void SetTable (Table	table)
		{
			m_table = table;
		}

		public Table GetTable ()
		{
			return m_table;
		}

		public TournamentMatch GetArenaMatch ()
		{
			return	m_arena_match;
		}

		public ActiveMatch GetActiveMatch ()
		{
			return m_active_match;
		}

		public void SetActiveMatch (ActiveMatch match)
		{
			m_active_match = match;

		}

		public Dictionary<string, World> Worlds {
			get {
				return m_worlds;
			}
			set {
				m_worlds = value; 
			}
		}




	}

}
