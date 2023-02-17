using System;
using Level.Views;
using UnityEngine;
using Utils.ProcessTool;

namespace Level.Processes
{
    public class PlayerInputProcess : Process
    {
        private float _chargeTime;
        private LevelCore _core;
        private PlayerView _player;
        private BulletView _bullet;
        private float _playerScale;
        
        public event Action onFire; 
        public PlayerInputProcess(LevelCore core) : base(core)
        {
            _core = core;
            _player = _core.model.playerView;
            _bullet = _core.factoryService.bullet.Produce();
            _playerScale = _player.transform.localScale.x;
        }

        protected override void OnUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                if(_player.transform.localScale.x <= 0) return;
                
                var scale = Time.deltaTime;
                _bullet.transform.localScale += new Vector3(scale, scale, scale);
                _bullet.transform.position = new Vector3(_player.transform.position.x, _bullet.transform.localScale.y / 2.0f,
                    _player.transform.position.z + _playerScale / 2.0f);
                _player.ChangSize(scale);
                //_player.transform.localScale -= new Vector3(scale, scale, scale);
                //_player.transform.position = new Vector3(_player.transform.position.x,
                    //_player.transform.localScale.y / 2.0f, _player.transform.position.z);
            }
            if (Input.GetMouseButtonUp(0))
            {
                _core.model.bulletView = _bullet;
                onFire?.Invoke();
            }
        }

        //public PlayerInputProcess SubscribeOnFire(Action<float> callback)
        //{
            //_onFire = callback;
            //return this;
        //}
        /*protected override void OnUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                _chargeTime += Time.deltaTime;
            }

            if (Input.GetMouseButtonUp(0))
            {
                onFire?.Invoke(_chargeTime);
                _chargeTime = 0.0f;
            }
        }*/
    }
}