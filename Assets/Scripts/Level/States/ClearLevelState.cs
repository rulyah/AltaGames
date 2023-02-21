using Utils.StateMachineTool;

namespace Level.States
{
    public class ClearLevelState : State<LevelCore>
    {
        public ClearLevelState(LevelCore core) : base(core) {}
        
        public override void OnEnter()
        {
            core.factoryService.players.Release(core.model.playerView);
            core.factoryService.target.Release(core.model.portalView);
            core.factoryService.roads.Release(core.model.roadView);
            core.factoryService.singularity.Release(core.model.singularityView);
            
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