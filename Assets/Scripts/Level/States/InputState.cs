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
            var bullet = core.model.bulletView;
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