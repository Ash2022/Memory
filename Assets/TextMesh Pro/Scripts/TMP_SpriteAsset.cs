﻿// Copyright (C) 2014 - 2016 Stephan Bouchard - All Rights Reserved
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms


using UnityEngine;
using System.Collections.Generic;


namespace TMPro
{

    public class TMP_SpriteAsset : TMP_Asset
    {
        private Dictionary<int, int> m_UnicodeLookup;
        private Dictionary<int, int> m_NameLookup;

        /// <summary>
        /// Static reference to the default font asset included with TextMesh Pro.
        /// </summary>
        public static TMP_SpriteAsset defaultSpriteAsset
        {
            get
            {
                if (m_defaultSpriteAsset == null)
                {
                    m_defaultSpriteAsset = Resources.Load<TMP_SpriteAsset>("Sprite Assets/Default Sprite Asset");
                }

                return m_defaultSpriteAsset;
            }
        }
        public static TMP_SpriteAsset m_defaultSpriteAsset;
        
        
        // The texture which contains the sprites.
        public Texture spriteSheet;

        // List which contains the SpriteInfo for the sprites contained in the sprite sheet.
        public List<TMP_Sprite> spriteInfoList;

        /// <summary>
        /// Dictionary used to lookup the index of a given sprite based on a Unicode value.
        /// </summary>
        private Dictionary<int, int> m_SpriteUnicodeLookup;


        //private bool isEditingAsset;

        void OnEnable()
        {
            // Make sure we have a valid material.
            //if (this.material == null && !isEditingAsset)
            //   this.material = GetDefaultSpriteMaterial();
        }


#if UNITY_EDITOR
        /// <summary>
        /// 
        /// </summary>
        void OnValidate()
        {

            TMPro_EventManager.ON_SPRITE_ASSET_PROPERTY_CHANGED(true, this);
        }
#endif


        /// <summary>
        /// Create a material for the sprite asset.
        /// </summary>
        /// <returns></returns>
        Material GetDefaultSpriteMaterial()
        {
            //isEditingAsset = true;
            ShaderUtilities.GetShaderPropertyIDs();

            // Add a new material
            Shader shader = Shader.Find("TextMeshPro/Sprite");
            Material tempMaterial = new Material(shader);
            tempMaterial.SetTexture(ShaderUtilities.ID_MainTex, spriteSheet);
            tempMaterial.hideFlags = HideFlags.HideInHierarchy;

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.AddObjectToAsset(tempMaterial, this);
            UnityEditor.AssetDatabase.ImportAsset(UnityEditor.AssetDatabase.GetAssetPath(this));
#endif
            //isEditingAsset = false;

            return tempMaterial;
        }


        /// <summary>
        /// Function to update the sprite name and unicode lookup tables.
        /// </summary>
        public void UpdateLookupTables()
        {
            if (m_NameLookup == null) m_NameLookup = new Dictionary<int, int>();

            if (m_UnicodeLookup == null) m_UnicodeLookup = new Dictionary<int, int>();

            for (int i = 0; i < spriteInfoList.Count; i++)
            {
                int nameHashCode = spriteInfoList[i].hashCode;

                if (m_NameLookup.ContainsKey(nameHashCode) == false)
                    m_NameLookup.Add(nameHashCode, i);

                int unicode = spriteInfoList[i].unicode;

                if (m_UnicodeLookup.ContainsKey(unicode) == false)
                    m_UnicodeLookup.Add(unicode, i);
            }
        }


        /// <summary>
        /// Function which returns the sprite index using the hashcode of the name
        /// </summary>
        /// <param name="hashCode"></param>
        /// <returns></returns>
        public int GetSpriteIndexFromHashcode(int hashCode)
        {
            if (m_NameLookup == null)
                UpdateLookupTables();

            int index = 0;
            if (m_NameLookup.TryGetValue(hashCode, out index))
                return index;

            return -1;
        }


        /// <summary>
        /// Returns the index of the sprite for the given unicode value.
        /// </summary>
        /// <param name="unicode"></param>
        /// <returns></returns>
        public int GetSpriteIndexFromUnicode (int unicode)
        {
            if (m_UnicodeLookup == null)
                UpdateLookupTables();

            int index = 0;

            if (m_UnicodeLookup.TryGetValue(unicode, out index))
                return index;

            return -1;
        }


/*
#if UNITY_EDITOR
        /// <summary>
        /// 
        /// </summary>
        public void LoadSprites()
        {
            if (m_sprites != null && m_sprites.Count > 0)
                return;

            Debug.Log("Loading Sprite List");
            
            string filePath = UnityEditor.AssetDatabase.GetAssetPath(spriteSheet);

            Object[] objects = UnityEditor.AssetDatabase.LoadAllAssetsAtPath(filePath);

            m_sprites = new List<Sprite>();

            foreach (Object obj in objects)
            {
                if (obj.GetType() == typeof(Sprite))
                {
                    Sprite sprite = obj as Sprite;
                    Debug.Log("Sprite # " + m_sprites.Count + " Rect: " + sprite.rect);
                    m_sprites.Add(sprite);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Sprite> GetSprites()
        {
            if (m_sprites != null && m_sprites.Count > 0)
                return m_sprites;

            //Debug.Log("Loading Sprite List");

            string filePath = UnityEditor.AssetDatabase.GetAssetPath(spriteSheet);

            Object[] objects = UnityEditor.AssetDatabase.LoadAllAssetsAtPath(filePath);

            m_sprites = new List<Sprite>();

            foreach (Object obj in objects)
            {
                if (obj.GetType() == typeof(Sprite))
                {
                    Sprite sprite = obj as Sprite;
                    //Debug.Log("Sprite # " + m_sprites.Count + " Rect: " + sprite.rect);
                    m_sprites.Add(sprite);
                }
            }

            return m_sprites;
        }
#endif
*/      
    }
}
