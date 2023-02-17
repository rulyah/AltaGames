using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class RoadView : PoolableMonoBehaviour
    {
        public void ChangeScale(float scaleX)
        {
            scaleX /= 10.0f;
            transform.localScale = new Vector3(transform.localScale.x - scaleX, transform.localScale.y, transform.localScale.z);
        }
    }
}