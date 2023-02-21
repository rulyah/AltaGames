using System.Collections.Generic;
using Level.Views;
using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class CorrectDifficultState : State<LevelCore>
    {
        public CorrectDifficultState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            core.model.currentObstacles ??= new List<ObstacleView>();
            core.model.currentObstacles.Clear();
            
            var obstacles = core.model.obstacles.FindAll(n =>
                n.transform.position.x < core.model.playerView.transform.localScale.x / 2.5f &&
                n.transform.position.x > -core.model.playerView.transform.localScale.x / 2.5f);
            
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
                
                if(core.model.currentObstacles.Count >= core.config.maxCurrentObstacleCount)
                {
                    for (var i = 0; i < core.model.currentObstacles.Count; i++)
                    {
                        var obstacle = core.model.currentObstacles[i];
                        core.model.currentObstacles[i].transform.position = new Vector3(Random.Range(-1.5f, 1.5f),
                            obstacle.transform.position.y, obstacle.transform.position.z);
                    }
                }
                ChangeState(new InputState(core));
            }
            else
            {
                ChangeState(new MovePlayerState(core));
            }
        }
    }
}