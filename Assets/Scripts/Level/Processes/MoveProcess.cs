using System;
using UnityEngine;
using Utils.ProcessTool;

namespace Level.Processes
{
    public class MoveProcess : Process
    {
        private readonly LevelCore _core;
        public event Action onCameToTarget;
        
        public MoveProcess(LevelCore core ) : base(core)
        {
            _core = core;
        }

        protected override void OnUpdate()
        {
            var distance = Vector3.Distance(_core.model.bulletView.transform.position,
                _core.model.targetView.transform.position);
            if (distance <= _core.config.distanceToVictory)
            {
                onCameToTarget?.Invoke();
            }
        }
    }
}