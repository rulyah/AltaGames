using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class ClearLevelState : State<LevelCore>
    {
        public ClearLevelState(LevelCore core) : base(core) {}
        
        public override void OnEnter()
        {
            Debug.Log("ClearLevelState");
            /*while(core.model.processes.Count > 0)
            {
                var process = core.model.processes[0];
                process.Stop();
                core.model.processes.Remove(process);
            }*/

            core.factoryService.players.Release(core.model.playerView);
            core.factoryService.target.Release(core.model.targetView);
            core.factoryService.roads.Release(core.model.roadView);
            //core.factoryService.bullet.Release(core.model.bulletView);
            
            while (core.model.obstacles.Count > 0)
            {
                var obstacle = core.model.obstacles[0];
                core.model.obstacles.Remove(obstacle);
                core.factoryService.obstacle.Release(obstacle);
            }
            ChangeState(new PrepareLevelState(core));
        }
    }
}