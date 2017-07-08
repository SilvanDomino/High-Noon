using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform
{
    public class PlatformHealth : MonoBehaviour
    {
        [SerializeField]
        private int _health = 5;

        public int Health
        {
            get { return _health; }
        }

        public void DamageHealth(int damage)
        {
            this._health -= damage;
            if(this._health <= 0)
            {
                //destroy tile
            }
        }
    }
}

