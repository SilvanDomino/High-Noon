using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, BulletSystem.ICollidable
{
    public delegate void PlayerDeath(Player player);
    public static event PlayerDeath OnPlayerDeath;

    public int ID { get; private set; }

    public void Collide()
    {
        KillPlayer();
    }

    private void KillPlayer()
    {
        if (OnPlayerDeath != null)
            OnPlayerDeath(this);
        
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // KillPlayer();
    }
}
