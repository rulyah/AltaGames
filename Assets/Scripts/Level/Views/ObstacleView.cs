using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class ObstacleView : PoolableMonoBehaviour
    {
        [SerializeField] private MeshRenderer _mesh;
        private Color _baseColor;
        private Color _infectColor = Color.yellow;

        public bool isInfected;

        private void Awake()
        {
            _baseColor = _mesh.material.color;
        }
        
        public void ChangeColor()
        {
            _mesh.material.color = isInfected ? _infectColor : _baseColor;
        }

        public void Reset()
        {
            isInfected = false;
            ChangeColor();
        }
    }
}