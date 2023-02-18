using System.Collections.Generic;
using Level.Views;
using Utils.StateMachineTool;

namespace Level.States
{
    public class FindEnemyState : State<LevelCore>
    {
        public FindEnemyState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            core.model.currentObstacles ??= new List<ObstacleView>();
            core.model.currentObstacles.Clear();
            
            var obstacles = core.model.obstacles.FindAll(n =>
                n.transform.position.x < core.model.playerView.transform.localScale.x / 2.0f + 0.5f &&
                n.transform.position.x > -core.model.playerView.transform.localScale.x / 2.0f - 0.5f);
            
            if(obstacles.Count > 0)
            {
                for (var i = 0; i < obstacles.Count; i++)
                {
                    core.model.currentObstacles.Add(obstacles[i]);
                }
                
                while (core.model.currentObstacles.Count > core.config.maxCurrentObstacleCount)
                {
                    var obstacle = core.model.currentObstacles[0];
                    core.model.obstacles.Remove(obstacle);
                    core.model.currentObstacles.Remove(obstacle);
                    core.factoryService.obstacle.Release(obstacle);
                }
                ChangeState(new InputState(core));
            }
        }
    }
}