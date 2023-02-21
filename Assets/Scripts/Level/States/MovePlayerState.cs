using Level.Views;
using Utils.StateMachineTool;

namespace Level.States
{
    public class MovePlayerState : State<LevelCore>
    {
        public MovePlayerState(LevelCore core) : base(core) {}
        private PlayerView _player;
        
        public override void OnEnter()
        {
            if (core.model.singularityView.isActivate == false)
            {
                core.model.portalView.SwitchPortal();
                core.model.singularityView.gameObject.SetActive(true);
                core.model.singularityView.isActivate = true;
            }

            _player = core.model.playerView;
            _player.PlayMove(core.config.bulletSpeed);
            _player.onTargetCollision += OnTargetCollision;
        }

        private void OnTargetCollision()
        {
            _player.Refresh();
            ChangeState(new VictoryState(core));
        }
    }
}