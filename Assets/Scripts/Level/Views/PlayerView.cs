using System;
using System.Collections;
using UnityEngine;

namespace Level.Views
{
    public class PlayerView : Player
    {
        private Animator _animator;
        private float _moveSpeed;
        private static readonly int _rollAnim = Animator.StringToHash("Roll_Anim");
        public event Action onTargetCollision;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                onTargetCollision?.Invoke();
            }
        }

        public override void ChangeSize(float bulletSize)
        {
            transform.localScale -= new Vector3(bulletSize,bulletSize,bulletSize);
        }

        public override void PlayMove(float speed)
        {
            StartCoroutine(Move(() => _moveSpeed = speed));
        }

        public override void Refresh()
        {
            _moveSpeed = 0.0f;
            _animator.SetBool(_rollAnim, false);
        }

        private IEnumerator Move(Action action)
        {
            _animator.SetBool(_rollAnim, true);
            yield return new WaitForSeconds(2.0f);
            action?.Invoke();
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
