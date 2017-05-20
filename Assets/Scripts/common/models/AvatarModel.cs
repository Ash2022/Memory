using UnityEngine;
using System.Collections;
using System;

namespace common.models
{

	public class AvatarModel  
	{

		public enum Gender		{
			Male,
			Female
		}

		int						m_head_index=0;
		int						m_face_index=0;
		int						m_hair_index=0;
		int						m_hair_color_index=0;
		int						m_skin_index=0;
		int						m_gender_index=0;//0-male 1-female
		string 					m_nick_name;



		bool					m_is_facebook_linked=false;
		bool					m_facebook_avatar_used=false;

		string 					m_external_fb_picture;


		public event Action OnAvatarDataChange;

		public AvatarModel ()
		{
			
		}

		public void CopyAvatar(AvatarModel av_model)
		{
			m_gender_index=av_model.m_gender_index;//0-male 1-female
			m_head_index=av_model.m_head_index;
			m_face_index = av_model.m_face_index;
			m_hair_index = av_model.m_hair_index;
			m_hair_color_index = av_model.m_hair_color_index;
			m_skin_index = av_model.m_skin_index;
			m_nick_name = av_model.m_nick_name;
			m_is_facebook_linked = av_model.m_is_facebook_linked;
			m_facebook_avatar_used = av_model.Facebook_avatar_used;

			if(OnAvatarDataChange!=null)
				OnAvatarDataChange();

		}
	
		public void SetHeadIndex(int index)
		{
			m_head_index = index;
			if(OnAvatarDataChange!=null)
				OnAvatarDataChange();
		}

		public void SetHairFrontIndex(int index)
		{
			m_hair_index = index;
			if(OnAvatarDataChange!=null)
				OnAvatarDataChange();
		}

		public void SetFaceIndex(int index)
		{
			m_face_index = index;
			if(OnAvatarDataChange!=null)
				OnAvatarDataChange();
		}

		public void SetHairColorIndex(int index)
		{
			m_hair_color_index = index;
			if(OnAvatarDataChange!=null)
				OnAvatarDataChange();
		}

		public void SetSkinIndex(int index)
		{
			m_skin_index = index;
			if(OnAvatarDataChange!=null)
				OnAvatarDataChange();
		}

		public void SetGenderIndex(int index)
		{
			m_gender_index = index;
			if(OnAvatarDataChange!=null)
				OnAvatarDataChange();
		}

		public void SetNickName(string nick_name)
		{
			m_nick_name = nick_name;
			if(OnAvatarDataChange!=null)
				OnAvatarDataChange();
		}

		public string GetNickName()
		{
			return m_nick_name;
		}

		public int GetHeadIndex()
		{
			return m_head_index;
		}

		public int GetHairFrontIndex()
		{
			return m_hair_index;
		}


		public int GetFaceIndex()
		{
			return m_face_index;
		}

		public int GetHairColorIndex()
		{
			return m_hair_color_index;
		}

		public int GetSkinIndex()
		{
			return m_skin_index;
		}

		public int GetGenderIndex()
		{
			return m_gender_index;
		}

		public bool Is_facebook_linked {
			get {
				return m_is_facebook_linked;
			}
			set{
				m_is_facebook_linked = value;
				//if(OnAvatarDataChange!=null)
					//OnAvatarDataChange ();
			}
		}



		public bool Facebook_avatar_used {
			get {
				return m_facebook_avatar_used;
			}
			set {
				m_facebook_avatar_used = value;
				if(OnAvatarDataChange!=null)
					OnAvatarDataChange();
			}
		}

		public string External_fb_picture {
			get {
				return this.m_external_fb_picture;
			}
			set {
				m_external_fb_picture = value;
			}
		}


	}
}