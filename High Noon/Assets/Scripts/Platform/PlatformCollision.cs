using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform
{
    
    public class PlatformCollision : MonoBehaviour, BulletSystem.ICollidable
    {
        public PlatformHealth _platformHealth;

        void Start()
        {
            _platformHealth = gameObject.GetComponent<PlatformHealth>();
        }

        public void Collide()
        {
            _platformHealth.DamageHealth(1);
        }

        public void Land()
        {

        }
    }
}

