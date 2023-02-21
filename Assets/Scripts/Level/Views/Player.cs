using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public abstract class Player : PoolableMonoBehaviour
    {
        public abstract void ChangeSize(float size);
        public abstract void PlayMove(float speed);
        public abstract void Refresh();
    }
}