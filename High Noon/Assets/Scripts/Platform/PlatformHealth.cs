using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform
{
    public class PlatformHealth : MonoBehaviour
    {
        [SerializeField]
        private int _health = 5;

        private GameObject _particleSystem;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public GameObject SetParticleObject
        {
            set { _particleSystem = value; }
        }

        public void DamageHealth(int damage)
        {
            this._health -= damage;
            if(this._health <= 0)
            {
                //destroy tile
                DestroyPlatform();
            }
        }

        private void DestroyPlatform()
        {
            Destroy(this.gameObject, 0.1f);
            if (_particleSystem)
            {
                Instantiate<GameObject>(_particleSystem, transform.position, Quaternion.identity);
            }
            
        }
    }
}

