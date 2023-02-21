using Level.Processes;
using Utils.StateMachineTool;

namespace Level.States
{
    public class InputState : State<LevelCore>
    {
        public InputState(LevelCore core) : base(core) {}
        private PlayerInputProcess _inputProcess;
        public override void OnEnter()
        {
            core.gameScreen.Show();
            _inputProcess = new PlayerInputProcess(core);
            _inputProcess.Start();
            _inputProcess.onFire += OnFire;
        }

        private void OnFire()
        {
            var player = core.model.playerView;
            var bullet = core.model.bulletView;
            if (bullet.transform.localScale.x < core.config.minSize)
            {
                var size = core.config.minSize - bullet.transform.localScale.x;
                bullet.ChangeSize(size);
                player.ChangeSize(size);
            }

            if (player.transform.localScale.x < core.config.minSize)
            {
                bullet.ChangeSize(player.transform.localScale.x);
                player.ChangeSize(player.transform.localScale.x);
            }
            
            bullet.PlayMove(core.config.bulletSpeed);
            ChangeState(new CheckBulletCollisionState(core));
        }

        public override void OnExit()
        {
            _inputProcess.onFire -= OnFire;
            _inputProcess.Stop();
        }
    }
}