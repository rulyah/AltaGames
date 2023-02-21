using System.Collections.Generic;
using Level.Views;
using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class PrepareLevelState : State<LevelCore>
    {
        public PrepareLevelState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            core.model.obstacles ??= new List<ObstacleView>();
            SetPlayer();
            SetTarget();
            SetSingularity();
            SetRoad();
            SetObstacle();
            ChangeState(new CorrectDifficultState(core));
        }

        private void SetPlayer()
        {
            core.model.playerView = core.factoryService.players.Produce();
            core.model.playerView.transform.localScale = core.config.playerStartSize;
            core.model.playerView.transform.position = core.config.startPlayerPos;
        }

        private void SetTarget()
        {
            core.model.portalView = core.factoryService.target.Produce();
            core.model.portalView.transform.position = core.config.startTargetPos;
        }

        private void SetRoad()
        {
            var distance = Vector3.Distance(core.model.playerView.transform.position,
                core.model.portalView.transform.position);
            
            core.model.roadView = core.factoryService.roads.Produce();
            core.model.roadView.transform.position = Vector3.zero;
            
            core.model.roadView.transform.localScale = new Vector3(
                core.model.playerView.transform.localScale.x / 10.0f,
                core.model.roadView.transform.localScale.y,
                distance / 10.0f);
        }

        private void SetObstacle()
        {
            for (var i = 0; i < 200; i++)
            {
                var obstacle = core.factoryService.obstacle.Produce();
                obstacle.transform.position = Random.insideUnitSphere * core.config.spawnRadius;
                obstacle.transform.position = new Vector3(obstacle.transform.position.x,
                    0.0f, obstacle.transform.position.z);
                core.model.obstacles.Add(obstacle);
            }
        }
        
        private void SetSingularity()
        {
            core.model.singularityView = core.factoryService.singularity.Produce();
            core.model.singularityView.gameObject.SetActive(false);
            core.model.singularityView.transform.position = 
                new Vector3(core.model.portalView.transform.position.x, 3.5f, core.model.portalView.transform.position.z);
        }
    }
}