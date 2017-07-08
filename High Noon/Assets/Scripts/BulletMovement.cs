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

        [Header("Collision")]
        [SerializeField]
        private LayerMask _layer;
        private float _skinSize = 0.4f;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rotationSpeed = Random.Range(_rotationSpeedMin, _rotationSpeedMax);
            _currentSpeed = _initialsSpeed;
        }

        private void Update()
        {
            var hit = Physics2D.Raycast(transform.position, new Vector2(transform.up.x, transform.up.y), _skinSize,
                _layer);
            if (hit.collider != null)
            {
                BulletCollision(hit);
            }

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

        private void BulletCollision(RaycastHit2D hit)
        {
            var collidable = hit.collider.GetComponent<ICollidable>();
            if (collidable != null)
            {
                collidable.Collide();
            }
            
            var newDirection = Vector2.Reflect(transform.up, hit.normal);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, newDirection);
        }
    }
}