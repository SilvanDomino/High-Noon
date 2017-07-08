using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    [SerializeField]
    private Texture2D _level;

    [SerializeField]
    private GameObject _platformSprite;


    void Start()
    {
        //parent of all the cubes
        this.name = "Level";
        

        for (int x = 0; x < _level.width; x++)
        {
            for (int y = 0; y < _level.height; y++)
            {
                Color pixel = _level.GetPixel(x, y);
                if (pixel == Color.black)
                {
                    GameObject platform = (GameObject)Instantiate(_platformSprite, new Vector3(x - 12.5f, y - 7.5f, 0), Quaternion.identity);
                    platform.transform.SetParent(this.transform);
                }
            }
        }
    }


}