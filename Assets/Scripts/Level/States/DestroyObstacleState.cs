using System;
using System.Collections;
using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class DestroyObstacleState : State<LevelCore>
    {
        public DestroyObstacleState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            core.StartCoroutine(Delay(1.0f, () =>
            {
                foreach (var obstacle in core.model.currentObstacles.FindAll(n => n.isInfected))
                {
                    core.model.obstacles.Remove(obstacle);
                    obstacle.Reset();
                    core.factoryService.obstacle.Release(obstacle);
                }
                if (core.model.playerView.transform.localScale.x <= 0.0f)
                {
                    core.gameScreen.Hide();
                    ChangeState(new LossState(core));
                }
                else ChangeState(new InputState(core));
            }));
        }

        private IEnumerator Delay(float waitTime, Action action)
        {
            yield return new WaitForSeconds(waitTime);
            action?.Invoke();
        }
    }
}