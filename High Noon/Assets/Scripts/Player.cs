using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    public delegate void PlayerDeath(Player player);
    public static event PlayerDeath OnPlayerDeath;

    public int ID { get; private set; }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (OnPlayerDeath != null)
            OnPlayerDeath(this);
        
        Destroy(gameObject);
    }
}
