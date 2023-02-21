using System;
using Level.Views;
using UnityEngine;
using Utils.ProcessTool;

namespace Level.Processes
{
    public class MoveProcess : Process
    {
        private readonly LevelCore _core;
        private Player _player;
        public event Action onCameToTarget;
        
        public MoveProcess(LevelCore core, Player player ) : base(core)
        {
            _core = core;
            _player = player;
        }

        protected override void OnUpdate()
        {
            if (_core.model.singularityView.isActivate == false)
            {
                var distance = Vector3.Distance(_player.transform.position,
                    _core.model.portalView.transform.position);

                if (distance <= _core.config.distanceToVictory)
                {
                    onCameToTarget?.Invoke();
                }
            }
        }
    }
}