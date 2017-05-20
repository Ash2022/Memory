using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using common.models;

namespace memory.models

{
	/// <summary>
	/// Manages the player and holds a reference to the cards models.
	/// </summary>
public class Player {

		int			m_tablepos;
		int			m_score;
		bool 		m_IsHuman;

		AvatarModel m_av_model;


		public Player(int tablepos, int score, bool isHuman, AvatarModel av_model)
		{
			m_tablepos=tablepos;
			m_score = score;
			m_IsHuman = isHuman;
			m_av_model = av_model;


		}

		public AvatarModel GetAvatarModel()
		{
			return m_av_model;
		}


		public int GetScore()
		{
			return m_score;
		}
		public int GetTablePos()
		{
			return	m_tablepos;
		}

		public bool	GetHuman()
		{
			return m_IsHuman;
		}

		public string GetName()
		{
			return m_av_model.GetNickName ();
		}

}


}