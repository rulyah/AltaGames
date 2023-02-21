using System.Collections.Generic;
using Level.Views;

namespace Level
{
    public class LevelModel
    {
        public PlayerView playerView;
        public RoadView roadView;
        public PortalView portalView;
        public BulletView bulletView;
        public SingularityView singularityView;
        public ExplosionView explosionView;
        public List<ObstacleView> obstacles;
        public List<ObstacleView> currentObstacles;
    }
}