using System;
using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class ObstacleView : PoolableMonoBehaviour
    {
        [SerializeField] private MeshRenderer _mesh;
        private Color _baseColor = Color.green;
        private Color _infectColor = Color.yellow;

        public bool isInfected = false;

        public void ChangeColor()
        {
            _mesh.material.color = isInfected ? _infectColor : _baseColor;
        }
    }
}