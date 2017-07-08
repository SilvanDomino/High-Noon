﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform
{
    public class LevelCreator : MonoBehaviour
    {
        [SerializeField]
        private Platform.Tile[] tiles = new Platform.Tile[2];

        [SerializeField]
        private Texture2D _level;

        [SerializeField]
        private GameObject _platformSprite;


        void Start()
        {
            //parent of all the cubes
            this.name = "Level";

            for (int x = 0; x < _level.width; x++) //run through all the pixels and get the colors
            {
                for (int y = 0; y < _level.height; y++)
                {
                    Color pixel = _level.GetPixel(x, y);

                    foreach(Tile t in tiles)    //run trough all the tiles in order to check for color tag
                    {
                        if(pixel.a > 0.9f && pixel == t.color)
                        {
                            GameObject platform = CreateTile(t); //create a tile specific to the corresponding pixel
                            platform.transform.position = new Vector3(x - 12.5f, y-7.5f, 0);
                            platform.transform.SetParent(this.transform);
                        }
                        
                    }
                }
            }
        }

        private GameObject CreateTile(Tile t)
        {
            GameObject go = (GameObject)Instantiate(_platformSprite);
            go.GetComponent<PlatformHealth>().Health = t.health;
            go.GetComponent<SpriteRenderer>().sprite = t.sprite;
            return go;
        }
    }

    [System.Serializable]
    struct Tile
    {
        public string tag;
        public int health;
        public Color color;
        public Sprite sprite;
        public ParticleSystem death;
    }
}
