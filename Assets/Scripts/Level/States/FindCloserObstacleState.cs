using Level.Views;
using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class FindCloserObstacleState : State<LevelCore>
    {
        private ObstacleView _obstacle;

        public FindCloserObstacleState(LevelCore core, ObstacleView obstacleView) : base(core)
        {
            _obstacle = obstacleView;
        }

        public override void OnEnter()
        {
            _obstacle.ChangeColor();
            _obstacle.isInfected = true;
            
            for (var i = 0; i < core.model.currentObstacles.Count; i++)
            {
                var distance = Vector3.Distance(_obstacle.transform.position,
                    core.model.currentObstacles[i].transform.position);
                if (distance <= core.model.bulletView.transform.localScale.x * 2.0f)
                {
                    core.model.currentObstacles[i].ChangeColor();
                }
            }
            ChangeState(new DestroyObstacleState(core));
        }
    }
}