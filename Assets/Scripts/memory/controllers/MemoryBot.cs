using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using common;
using memory.models;


namespace memory.controllers
{
	/// <summary>
	/// a bot player AI - holds link to its player model and table model
	/// </summary>
	public class MemoryBot
	{

		Player m_player;
		Table m_table;

	
		public void SetPlayer (Player player)
		{
			m_player = player;
		}

		public void SetTable (Table table)
		{
			m_table = table;
		}



	}
}