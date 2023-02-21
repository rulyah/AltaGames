using System;
using UnityEngine;

namespace Level.Views
{
    public class BulletView : Player
    {
        private Animator _animator;
        private float _moveSpeed;
        private static readonly int _walkAnim = Animator.StringToHash("Walk_Anim");
        private static readonly int _walkFloat = Animator.StringToHash("WalkFloat");

        public event Action<ObstacleView> onObstacleCollision;
        public event Action onTargetCollision;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public override void ChangeSize(float size)
        {
            transform.localScale += new Vector3(size,size,size);
        }

        public override void PlayMove(float speed)
        {
            _animator.SetBool(_walkAnim, true);
            _animator.SetFloat(_walkFloat,2.0f);
            _moveSpeed = speed;
        }
        
        public override void Refresh()
        {
            _animator.SetBool(_walkAnim, false);
            _animator.SetFloat(_walkFloat,0.0f);

            transform.localScale = Vector3.zero;
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            _moveSpeed = 0.0f;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                _animator.SetBool(_walkAnim, false);
                onObstacleCollision?.Invoke(collision.gameObject.GetComponent<ObstacleView>());
            }
            if (collision.gameObject.CompareTag($"Target"))
            {
                onTargetCollision?.Invoke();
            }
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