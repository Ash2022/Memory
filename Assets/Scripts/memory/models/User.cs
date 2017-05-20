using UnityEngine;
using System.Collections;
using System;
using common.models;


namespace memory.models
{
	public class User 
	{
		int				m_user_id;
		int				m_coins_balance;
		int				m_gems_balance;
		int				m_xp;
		int 			m_level;
		string 			m_country;
		AvatarModel		m_avatar;

		public event Action<int> OnXPChange;
		public event Action<int> OnLevelChange;

	

		public User()
		{
			m_user_id = 0;
			m_coins_balance = 0;
			m_gems_balance = 0;
			m_level = 0;
			m_xp = 0;
			m_country = "";
			m_avatar = new AvatarModel();
		
		}


	}
}