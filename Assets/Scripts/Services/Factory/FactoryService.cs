using Level.Views;
using UnityEngine;
using Utils.FactoryTool;

namespace Services.Factory
{
    public class FactoryService : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private RoadView _roadPrefab;
        [SerializeField] private PortalView portalPrefab;
        [SerializeField] private ObstacleView _obstaclePrefab;
        [SerializeField] private BulletView _bulletPrefab;
        [SerializeField] private SingularityView _singularityPrefab;
        [SerializeField] private ExplosionView _explosionPrefab;

        
        public Factory<PlayerView> players { get; private set; }
        public Factory<RoadView> roads { get; private set; }
        public Factory<PortalView> target { get; private set; }
        public Factory<ObstacleView> obstacle { get; private set; }
        public Factory<BulletView> bullet { get; private set; }
        public Factory<SingularityView> singularity { get; private set; }
        public Factory<ExplosionView> explosion { get; private set; }




        private void Awake()
        {
            players = new Factory<PlayerView>(_playerPrefab, 1);
            roads = new Factory<RoadView>(_roadPrefab, 1);
            target = new Factory<PortalView>(portalPrefab, 1);
            obstacle = new Factory<ObstacleView>(_obstaclePrefab, 200);
            bullet = new Factory<BulletView>(_bulletPrefab, 1);
            singularity = new Factory<SingularityView>(_singularityPrefab, 1);
            explosion = new Factory<ExplosionView>(_explosionPrefab, 1);
        }

        private void OnDestroy()
        {
            players.Dispose();
            roads.Dispose();
            target.Dispose();
            obstacle.Dispose();
        }
    }
}
