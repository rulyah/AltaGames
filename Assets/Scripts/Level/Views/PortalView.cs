using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class PortalView : PoolableMonoBehaviour
    {
        [SerializeField] private GameObject _portalHolder;
        private bool _isActive;
        public void SwitchPortal()
        {
            _isActive = !_isActive;
            _portalHolder.gameObject.SetActive(!_isActive);
        }
        
        public override void Dispose()
        {
            _isActive = false;
            _portalHolder.gameObject.SetActive(!_isActive);
        }
    }
}