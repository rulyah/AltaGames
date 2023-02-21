using System;
using System.Collections;
using Level.Views;
using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class DestroyCloserObstacleState : State<LevelCore>
    {
        private ObstacleView _obstacle;

        public DestroyCloserObstacleState(LevelCore core, ObstacleView obstacleView) : base(core)
        {
            _obstacle = obstacleView;
        }

        public override void OnEnter()
        {
            core.model.explosionView = core.factoryService.explosion.Produce();
            core.model.explosionView.transform.position = core.model.bulletView.transform.position;

            core.StartCoroutine(Delay(0.5f, () =>
            {
                if (core.model.currentObstacles.Count > 0)
                {
                    for (var i = 0; i < core.model.currentObstacles.Count; i++)
                    {
                        var distance = Vector3.Distance(_obstacle.transform.position,
                            core.model.currentObstacles[i].transform.position);

                        if (distance <= core.model.bulletView.transform.localScale.x * 3.0f)
                        {
                            var obstacle = core.model.currentObstacles[i];
                            core.model.currentObstacles.Remove(obstacle);
                            core.factoryService.obstacle.Release(obstacle);
                        }
                        Debug.Log(core.model.currentObstacles.Count);
                    }
                    
                    core.model.bulletView.Refresh();
                    core.factoryService.bullet.Release(core.model.bulletView);
                    core.model.obstacles.Remove(_obstacle);
                    core.factoryService.obstacle.Release(_obstacle);

                    if (core.model.playerView.transform.localScale.x <= 0.0f)
                    {
                        core.gameScreen.Hide();
                        ChangeState(new LossState(core));
                    }
                    else ChangeState(new CorrectDifficultState(core));
                }
                else
                {
                    core.model.bulletView.Refresh();
                    core.factoryService.bullet.Release(core.model.bulletView);
                    ChangeState(new MovePlayerState(core));
                }
            }));
        }

        public override void OnExit()
        {
            core.factoryService.explosion.Release(core.model.explosionView);
        }

        private IEnumerator Delay(float waitTime, Action action)
        {
            yield return new WaitForSeconds(waitTime);
            action?.Invoke();
        }
    }
}