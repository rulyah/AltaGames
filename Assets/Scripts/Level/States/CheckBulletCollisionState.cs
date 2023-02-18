using Level.Processes;
using Level.Views;
using Utils.StateMachineTool;

namespace Level.States
{
    public class CheckBulletCollisionState : State<LevelCore>
    {
        public CheckBulletCollisionState(LevelCore core) : base(core) {}
        private MoveProcess _moveProcess;
        public override void OnEnter()
        {
            core.model.bulletView.onObstacleCollision += OnObstacleCollision;
            core.model.bulletView.onTargetCollision += OnTargetCollision;
            _moveProcess = new MoveProcess(core);
            _moveProcess.Start();
            _moveProcess.onCameToTarget += OnCameToTarget;
        }

        private void OnCameToTarget()
        {
            core.factoryService.gate.Release(core.model.gateView);
        }

        public override void OnExit()
        {
            core.model.bulletView.onObstacleCollision -= OnObstacleCollision;
            core.model.bulletView.onTargetCollision -= OnTargetCollision;
            _moveProcess.onCameToTarget -= OnCameToTarget;
            _moveProcess.Stop();
        }

        private void OnObstacleCollision(ObstacleView obstacle)
        {
            core.model.bulletView.Reset();
            core.factoryService.bullet.Release(core.model.bulletView);
            ChangeState(new FindCloserObstacleState(core, obstacle));
        }

        private void OnTargetCollision()
        {
            core.model.bulletView.Reset();
            core.factoryService.bullet.Release(core.model.bulletView);
            ChangeState(new VictoryState(core));
        }
    }
}