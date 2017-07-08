using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BulletSystem
{
    /// <summary>
    /// The size of the level from zero pos
    /// generates colliders on start
    /// </summary>
    public class RoomBounds : MonoBehaviour
    {
        [SerializeField] private Vector2 _roomSize;
        public Vector2 RoomSize
        {
            get { return _roomSize;  }
        }

        private void Awake()
        {
            GenerateRoomBounds();
        }

        private void GenerateRoomBounds()
        {
            SpawnWall(Vector3.up * _roomSize.y, _roomSize);
            SpawnWall(Vector3.down * _roomSize.y, _roomSize);
            SpawnWall(Vector3.left * _roomSize.x, _roomSize);
            SpawnWall(Vector3.right * _roomSize.x, _roomSize);
        }

        private void SpawnWall(Vector3 position, Vector2 colliderSize)
        {
            var roomwall = new GameObject("Roomwall");
            roomwall.isStatic = true;
            roomwall.transform.position = position;
            roomwall.tag = TagManager.COLLIDER;
            
            var wallCollider= roomwall.AddComponent<BoxCollider2D>();
            wallCollider.size = colliderSize;
            roomwall.transform.SetParent(transform);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            var gizmoSize = new Vector3(_roomSize.x, _roomSize.y, 0);
            Gizmos.DrawWireCube(Vector3.zero, gizmoSize);
        } 
    }
}
