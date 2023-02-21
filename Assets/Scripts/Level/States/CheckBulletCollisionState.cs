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
            _moveProcess = new MoveProcess(core, core.model.bulletView);
            _moveProcess.Start();
            _moveProcess.onCameToTarget += OnCameToTarget;
        }

        private void OnCameToTarget()
        {
            core.model.portalView.SwitchPortal();
            core.model.singularityView.gameObject.SetActive(true);
            core.model.singularityView.isActivate = true;
            _moveProcess.Stop();
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
            core.model.currentObstacles.Remove(obstacle);
            ChangeState(new DestroyCloserObstacleState(core, obstacle));
        }

        private void OnTargetCollision()
        {
            core.model.bulletView.Refresh();
            core.factoryService.bullet.Release(core.model.bulletView);
            ChangeState(new VictoryState(core));
        }
    }
}