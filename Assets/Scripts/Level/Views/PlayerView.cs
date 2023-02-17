using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class PlayerView : PoolableMonoBehaviour
    {
        //private float _moveSpeed;

        /*public void Move(float speed)
        {
            _moveSpeed = speed;
        }*/

        public void ChangSize(float bulletSize)
        {
            transform.localScale -= new Vector3(bulletSize,bulletSize,bulletSize);
            ChangePosY(transform.localScale.y);
        }

        private void ChangePosY(float pos)
        {
            transform.position = new Vector3(transform.position.x, pos / 2.0f, transform.position.z);
        }
    }
}
