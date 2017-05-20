using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using common;
using System;
using common.models;
using System.Security.Cryptography;
using Facebook.Unity;

using Facebook.Unity.Settings;
using memory.models;


namespace memory.controllers
{

	public class LobbyController : MonoBehaviour
	{
		[SerializeField] GameObject m_lobby_object = null;
	
		static LobbyController		m_instance;

		[SerializeField]Camera				m_main_cam=null;	

		public static LobbyController 		Instance
		{
			get{

				if (m_instance == null)
				{
					LobbyController manager = GameObject.FindObjectOfType<LobbyController> ();
					m_instance = manager.GetComponent<LobbyController> ();
				}
				return m_instance;
			}
		}


	


	}
}