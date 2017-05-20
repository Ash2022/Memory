using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using memory.models;


namespace memory.controllers
{

	/// <summary>
	/// this class manages the entire round of play - holds references to the model manager and view manager - as well as to the game engine and all the bots
	/// </summary>

	public class MatchController : MonoBehaviour
	{

		MemoryEngine m_spades_engine;

		IEnumerator m_bidding_routine = null;

		static MatchController	m_instance;

	
		public static MatchController Instance {
			get {

				if (m_instance == null) {
					MatchController manager = GameObject.FindObjectOfType<MatchController> ();
					m_instance = manager.GetComponent<MatchController> ();
				}
				return m_instance;
			}
		}



	}

}
