using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using common;

using common.models;
using System.Collections.Generic;
using memory.models;


namespace memory.controllers
{

	public class AvatarController : MonoBehaviour {

		[SerializeField] Sprite[]			m_male_head_textures=null;
		[SerializeField] Texture[]			m_male_face_textures=null;
		[SerializeField] Sprite[]			m_male_hair_front_textures=null;
		[SerializeField] Sprite[]			m_male_hair_back_textures=null;

		[SerializeField] Color[]			m_male_hair_color;
		[SerializeField] Color[]			m_male_skin_color;

		[SerializeField] Sprite[]			m_female_head_textures=null;
		[SerializeField] Texture[]			m_female_face_textures=null;
		[SerializeField] Sprite[]			m_female_hair_front_textures=null;
		[SerializeField] Sprite[]			m_female_hair_back_textures=null;

		[SerializeField] Color[]			m_female_hair_color;
		[SerializeField] Color[]			m_female_skin_color;

		[SerializeField] Sprite[]			m_bases=null;	//0-cutblue 1-blue 2-red 3-nothing
		[SerializeField] Sprite[]			m_bid_signs=null;	//0-cutblue 1-blue 2-red 3-nothing
		[SerializeField] Material[]			m_avatar_materials=null;
		[SerializeField] Material[]			m_avatar_hair_materials=null;



		[SerializeField] GameObject			m_temp_avatar;


		[SerializeField]List<AnimationClip>		m_sad;
		[SerializeField]List<AnimationClip>		m_happy;
		[SerializeField]List<AnimationClip>		m_angry;
		[SerializeField]List<AnimationClip>		m_silly;
		[SerializeField]List<AnimationClip>		m_FB_sad;
		[SerializeField]List<AnimationClip>		m_FB_happy;
		[SerializeField]List<AnimationClip>		m_FB_angry;
		[SerializeField]List<AnimationClip>		m_FB_silly;
		[SerializeField]AnimationClip			m_speech_bubble;


		static AvatarController			    m_instance;

		public static AvatarController 		Instance
		{
			get{

				if (m_instance == null)
				{
					AvatarController manager = GameObject.FindObjectOfType<AvatarController> ();
					m_instance = manager.GetComponent<AvatarController> ();
					m_instance.GenerateColors ();
				}
				return m_instance;
			}
		}



		void GenerateColors()
		{
			m_male_skin_color = new Color[5];
			m_male_skin_color[0] = new Color((float)255/255,(float)189/255,(float)129/255);
			m_male_skin_color[1] = new Color((float)221/255,(float)161/255,(float)122/255);
			m_male_skin_color[2] = new Color((float)198/255,(float)158/255,(float)99/255);
			m_male_skin_color[3] = new Color((float)139/255,(float)88/255,(float)49/255);
			m_male_skin_color[4] = new Color((float)118/255,(float)67/255,(float)28/255); 

			m_male_hair_color = new Color[12];
			m_male_hair_color[0] = new Color((float)231/255,(float)215/255,(float)93/255);
			m_male_hair_color[1] = new Color((float)195/255,(float)66/255,(float)27/255);
			m_male_hair_color[2] = new Color((float)131/255,(float)5/255,(float)5/255);
			m_male_hair_color[3] = new Color((float)118/255,(float)80/255,(float)23/255);
			m_male_hair_color[4] = new Color((float)23/255,(float)24/255,(float)32/255);
			m_male_hair_color[5] = new Color((float)165/255,(float)165/255,(float)165/255);
			m_male_hair_color[6] = new Color((float)116/255,(float)116/255,(float)116/255);
			m_male_hair_color[7] = new Color((float)54/255,(float)31/255,(float)16/255);
			m_male_hair_color[8] = new Color((float)21/255,(float)172/255,(float)1/255);
			m_male_hair_color[9] = new Color((float)206/255,(float)67/255,(float)197/255);
			m_male_hair_color[10] = new Color((float)3/255,(float)44/255,(float)236/255);
			m_male_hair_color[11] = new Color((float)0/255,(float)208/255,(float)174/255);

			m_female_skin_color = new Color[5];
			m_female_skin_color[0] = new Color((float)255/255,(float)189/255,(float)129/255);
			m_female_skin_color[1] = new Color((float)221/255,(float)161/255,(float)122/255);
			m_female_skin_color[2] = new Color((float)198/255,(float)158/255,(float)99/255);
			m_female_skin_color[3] = new Color((float)139/255,(float)88/255,(float)49/255);
			m_female_skin_color[4] = new Color((float)118/255,(float)67/255,(float)28/255); 

			m_female_hair_color = new Color[12];
			m_female_hair_color[0] = new Color((float)231/255,(float)215/255,(float)93/255);
			m_female_hair_color[1] = new Color((float)195/255,(float)66/255,(float)27/255);
			m_female_hair_color[2] = new Color((float)131/255,(float)5/255,(float)5/255);
			m_female_hair_color[3] = new Color((float)118/255,(float)80/255,(float)23/255);
			m_female_hair_color[4] = new Color((float)23/255,(float)24/255,(float)32/255);
			m_female_hair_color[5] = new Color((float)165/255,(float)165/255,(float)165/255);
			m_female_hair_color[6] = new Color((float)116/255,(float)116/255,(float)116/255);
			m_female_hair_color[7] = new Color((float)54/255,(float)31/255,(float)16/255);
			m_female_hair_color[8] = new Color((float)21/255,(float)172/255,(float)1/255);
			m_female_hair_color[9] = new Color((float)206/255,(float)67/255,(float)197/255);
			m_female_hair_color[10] = new Color((float)3/255,(float)44/255,(float)236/255);
			m_female_hair_color[11] = new Color((float)0/255,(float)208/255,(float)174/255);

		}

		// Update is called once per frame


		public void RandomizeAvatar(AvatarModel av_model,bool randomize_gender)
		{
			if (randomize_gender)
			{
				int gender_index = Random.Range (0, 2);
				av_model.SetGenderIndex (gender_index);
			}

			int new_gender_index = av_model.GetGenderIndex();

			if (new_gender_index == 0)//male
			{
				av_model.SetHeadIndex (Random.Range (0, m_male_head_textures.Length));
				av_model.SetFaceIndex (Random.Range (0, m_male_face_textures.Length));
				av_model.SetHairFrontIndex (Random.Range (0, m_male_hair_front_textures.Length));
				av_model.SetSkinIndex (Random.Range (0, m_male_skin_color.Length));
				av_model.SetHairColorIndex (Random.Range (0, m_male_hair_color.Length));
			}
			else
			{
				av_model.SetHeadIndex (Random.Range (0, m_female_head_textures.Length));
				av_model.SetFaceIndex (Random.Range (0, m_female_face_textures.Length));
				av_model.SetHairFrontIndex (Random.Range (0, m_female_hair_front_textures.Length));
				av_model.SetSkinIndex (Random.Range (0, m_female_skin_color.Length));
				av_model.SetHairColorIndex (Random.Range (0, m_female_hair_color.Length));

			}


		}

		public void AvatarButtonClickedUp(AvatarModel av_model, int button)
		{
			
			int gender = av_model.GetGenderIndex();

			switch(button)
			{
			case(1):
				{
					int temp = av_model.GetHeadIndex();
					int temp2 = 0;
					if(gender>0)
						temp2 = m_female_head_textures.Length-1;
					else
						temp2 = m_male_head_textures.Length-1;

					if(temp<temp2)
						av_model.SetHeadIndex(temp+1);
					else
						av_model.SetHeadIndex(0);
					break;	
				}
			case(2):
				{
					int temp = av_model.GetFaceIndex();
					int temp2 = 0;
					if(gender>0)
						temp2 = m_female_face_textures.Length-1;
					else
						temp2 = m_male_face_textures.Length-1;
					
					if(temp<temp2)
						av_model.SetFaceIndex(temp+1);
					else
						av_model.SetFaceIndex(0);
					break;	
				}
			case(3):
				{
					int temp = av_model.GetSkinIndex();
					int temp2 = 0;
					if(gender>0)
						temp2 = m_female_skin_color.Length-1;
					else
						temp2 = m_male_skin_color.Length-1;
					
					if(temp<temp2)
						av_model.SetSkinIndex(temp+1);
					else
						av_model.SetSkinIndex(0);
					break;	
				}
			case(4):
				{
					int temp = av_model.GetHairFrontIndex();
					int temp2 = 0;
					if(gender>0)
						temp2 = m_female_hair_front_textures.Length-1;
					else
						temp2 = m_male_hair_front_textures.Length-1;
					
					if(temp<temp2)
						av_model.SetHairFrontIndex(temp+1);
					else
						av_model.SetHairFrontIndex(0);
					break;	
				}
			
			case(5):
				{	int temp = av_model.GetHairColorIndex();
					int temp2 = 0;
					if(gender>0)
						temp2 = m_female_hair_color.Length-1;
					else
						temp2 = m_male_hair_color.Length-1;
					
					if(temp<temp2)
						av_model.SetHairColorIndex(temp+1);
					else
						av_model.SetHairColorIndex(0);
					break;	
				}
			}

		}

		public void AvatarButtonClickedDown(AvatarModel av_model,int button)
		{
			int gender_index = av_model.GetGenderIndex();
			switch(button)
			{
			case(1):
				{
					int temp = av_model.GetHeadIndex();
					int temp2 = 0;
					if(gender_index>0)
						temp2 = m_female_head_textures.Length-1;
					else
						temp2 = m_male_head_textures.Length-1;
					if(temp>0)
						av_model.SetHeadIndex(temp-1);
					else
						av_model.SetHeadIndex(temp2);
					break;	
				}
			case(2):
				{
					int temp = av_model.GetFaceIndex();
					int temp2 = 0;
					if(gender_index>0)
						temp2 = m_female_face_textures.Length-1;
					else
						temp2 = m_male_face_textures.Length-1;
					
					if(temp>0)
						av_model.SetFaceIndex(temp-1);
					else
						av_model.SetFaceIndex(temp2);
					break;	
				}
			case(3):
				{
					int temp = av_model.GetSkinIndex();
					int temp2 = 0;
					if(gender_index>0)
						temp2 = m_female_skin_color.Length-1;
					else
						temp2 = m_male_skin_color.Length-1;
					
					if(temp>0)
						av_model.SetSkinIndex(temp-1);
					else
						av_model.SetSkinIndex(temp2);
					break;	
				}
			case(4):
				{
					int temp = av_model.GetHairFrontIndex();
					int temp2 = 0;
					if(gender_index>0)
						temp2 = m_female_hair_front_textures.Length-1;
					else
						temp2 = m_male_hair_front_textures.Length-1;
					
					if(temp>0)
						av_model.SetHairFrontIndex(temp-1);
					else
						av_model.SetHairFrontIndex(temp2);
					break;	
				}
			case(5):
				{
					int temp =av_model.GetHairColorIndex();
					int temp2 = 0;
					if(gender_index>0)
						temp2 = m_female_hair_color.Length-1;
					else
						temp2 = m_male_hair_color.Length-1;
					
					if(temp>0)
						av_model.SetHairColorIndex(temp-1);
					else
						av_model.SetHairColorIndex(temp2);
					break;	
				}
			}

		}

		public void ChangeGender(AvatarModel av_model,int gender_index)
		{

			if (av_model.GetGenderIndex () == 0)
			{
				if (av_model.GetHeadIndex () > m_female_head_textures.Length - 1)
					av_model.SetHeadIndex (0);
				
				if (av_model.GetHairFrontIndex () > m_female_hair_front_textures.Length - 1)
					av_model.SetHairFrontIndex (0);

				if (av_model.GetFaceIndex () > m_female_face_textures.Length - 1)
					av_model.SetFaceIndex (0);

			}
			else
			{
				if (av_model.GetHeadIndex () > m_male_head_textures.Length - 1)
					av_model.SetHeadIndex (0);

				if (av_model.GetHairFrontIndex () > m_male_hair_front_textures.Length - 1)
					av_model.SetHairFrontIndex (0);

				if (av_model.GetFaceIndex () > m_male_face_textures.Length - 1)
					av_model.SetFaceIndex (0);
			}

			av_model.SetGenderIndex(gender_index);

		}

		public Sprite[] Male_head_textures {
			get {
				return m_male_head_textures;
			}
		}

		public Texture[] Male_face_textures {
			get {
				return m_male_face_textures;
			}
		}

		public Sprite[] Male_hair_front_textures {
			get {
				return m_male_hair_front_textures;
			}
		}

		public Sprite[] Male_hair_back_textures {
			get {
				return m_male_hair_back_textures;
			}
		}

		public Color[] Male_hair_color {
			get {
				return m_male_hair_color;
			}
		}

		public Color[] Male_skin_color {
			get {
				return m_male_skin_color;
			}
		}

		public Sprite[] Female_head_textures {
			get {
				return m_female_head_textures;
			}
		}

		public Texture[] Female_face_textures {
			get {
				return m_female_face_textures;
			}
		}

		public Sprite[] Female_hair_front_textures {
			get {
				return m_female_hair_front_textures;
			}
		}

		public Sprite[] Female_hair_back_textures {
			get {
				return m_female_hair_back_textures;
			}
		}

		public Color[] Female_hair_color {
			get {
				return m_female_hair_color;
			}
		}

		public Color[] Female_skin_color {
			get {
				return m_female_skin_color;
			}
		}

		public Sprite[] Bases {
			get {
				return m_bases;
			}
		}

		public Material[] Avatar_materials {
			get {
				return m_avatar_materials;
			}
		}

		public Material[] Avatar_hair_materials {
			get {
				return m_avatar_hair_materials;
			}
		}



		public List<AnimationClip> Sad {
			get {
				return m_sad;
			}
		}

		public List<AnimationClip> Happy {
			get {
				return m_happy;
			}
		}

		public List<AnimationClip> Angry {
			get {
				return m_angry;
			}
		}

		public List<AnimationClip> FB_sad {
			get {
				return m_FB_sad;
			}
		}

		public List<AnimationClip> FB_happy {
			get {
				return m_FB_happy;
			}
		}

		public List<AnimationClip> FB_angry {
			get {
				return m_FB_angry;
			}
		}

		public List<AnimationClip> Silly {
			get {
				return m_silly;
			}
		}

		public List<AnimationClip> FB_silly {
			get {
				return m_FB_silly;
			}
		}

		public AnimationClip Speech_bubble {
			get {
				return m_speech_bubble;
			}
		}

		public Sprite[] Bid_signs {
			get {
				return m_bid_signs;
			}
		}
	}
}