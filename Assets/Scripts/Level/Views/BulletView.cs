using System;
using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class BulletView : PoolableMonoBehaviour
    {
        private float _moveSpeed;
        
        public event Action<ObstacleView> onObstacleCollision;
        public event Action onTargetCollision;


        public void Move(float speed)
        {
            _moveSpeed = speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                onObstacleCollision?.Invoke(collision.gameObject.GetComponent<ObstacleView>());
            }
            if (collision.gameObject.CompareTag($"Target"))
            {
                onTargetCollision?.Invoke();
            }
        }

        public void Reset()
        {
            transform.localScale = Vector3.zero;
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            _moveSpeed = 0.0f;
        }

        private void Update()
        {
            if (_moveSpeed > 0.0f)
            {
                transform.position += transform.forward * _moveSpeed * Time.deltaTime;
            }
        }
    }
}