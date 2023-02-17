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
            Debug.Log("DestroyObstacleState");
            
            core.StartCoroutine(Delay(1.0f, () =>
            {
                foreach (var obstacle in core.model.currentObstacles.FindAll(n => n.isInfected))
                {
                    core.model.obstacles.Remove(obstacle);
                    obstacle.ChangeColor();
                    obstacle.isInfected = false;
                    core.factoryService.obstacle.Release(obstacle);
                }
                //ChangeState(new FindEnemyState(core));
                if(core.model.playerView.transform.localScale.x <= 0.0f) ChangeState(new LossState(core));
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