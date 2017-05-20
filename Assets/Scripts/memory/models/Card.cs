using UnityEngine;
using System.Collections;


namespace memory.models
{

	public class Card
	{

		int 	m_color;
		int 	m_value;
		bool	m_wild;

		public Card (int color, int value,bool wild=false)
		{
			m_color = color;
			m_value = value;
			m_wild = wild;
		}

		public void PrintLog ()
		{
			Debug.Log ("Card Suit " + m_color + " Number" + m_value);
		}

		public int Value {
			get {
				return m_value;
			}
		}

		public int Color {
			get {
				return m_color;
			}
		}
	}

}
