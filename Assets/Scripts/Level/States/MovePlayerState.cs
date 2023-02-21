using Level.Processes;
using Level.Views;
using Unity.VisualScripting.FullSerializer.Internal.Converters;
using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class MovePlayerState : State<LevelCore>
    {
        public MovePlayerState(LevelCore core) : base(core) {}
        private PlayerView _player;
        
        //private MoveProcess _moveProcess;
        public override void OnEnter()
        {
            core.model.portalView.SwitchPortal();
            core.model.singularityView.gameObject.SetActive(true);
            core.model.singularityView.isActivate = true;
            _player = core.model.playerView;
            //_moveProcess = new MoveProcess(core, _player);
            //_moveProcess.Start();
            _player.PlayMove(core.config.bulletSpeed);
            //_moveProcess.onCameToTarget += OnCameToTarget;
            _player.onTargetCollision += OnTargetCollision;
        }

        private void OnTargetCollision()
        {
            _player.Refresh();
            ChangeState(new VictoryState(core));
        }

        /*private void OnCameToTarget()
        {
            _moveProcess.Stop();
        }*/
        
        public override void OnExit()
        {
            //_moveProcess.onCameToTarget -= OnCameToTarget;
            //_moveProcess.Stop();
        }
    }
}