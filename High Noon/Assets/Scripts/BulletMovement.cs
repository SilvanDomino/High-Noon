using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BulletSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMovement : MonoBehaviour
    {
        [Header("Countdown")] 
        [SerializeField] private float _rotationSpeedMin;
        [SerializeField] private float _rotationSpeedMax;
        private float _rotationSpeed;
        
        [Header("Gameplay")]
        [SerializeField] private float _initialsSpeed;
        private float _currentSpeed;
        private Rigidbody2D _rigidbody;

        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rotationSpeed = Random.Range(_rotationSpeedMin, _rotationSpeedMax);
            _currentSpeed = _initialsSpeed;
        }
        
        private void FixedUpdate()
        {
            switch (GameManager.Instance.CurrentState)
            {
                  case GameManager.GameState.Countdown:
                      _rigidbody.rotation += _rotationSpeed;// * Time.deltaTime;
                      break;
                      
                  case GameManager.GameState.Gameplay:
                      var velocity = new Vector2(transform.up.x, transform.up.y) * _currentSpeed * Time.deltaTime;
                      _rigidbody.MovePosition(_rigidbody.position + velocity);
                      break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            
            if (!other.gameObject.CompareTag(TagManager.COLLIDER)) return; 
                
            var collidable = other.gameObject.GetComponent<ICollidable>();
            if (collidable != null)
            {
                collidable.Collide();
            }
                
               
            BounceBullet(other);
        }

        private void BounceBullet(Collision2D other)
        {
            //print(other.contacts.Length);
            var newDirection = Vector2.Reflect(transform.up, other.contacts[0].normal);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, newDirection);
        }
    }
}