using System.Collections.Generic;
using Level.Views;
using Utils.ProcessTool;

namespace Level
{
    public class LevelModel
    {
        public PlayerView playerView;
        public RoadView roadView;
        public TargetView targetView;
        public BulletView bulletView;
        public GateView gateView;
        public List<Process> processes;
        public List<ObstacleView> obstacles;
        public List<ObstacleView> currentObstacles;
    }
}