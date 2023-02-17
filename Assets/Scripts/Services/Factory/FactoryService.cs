using Level.Views;
using UnityEngine;
using Utils.FactoryTool;

namespace Services.Factory
{
    public class FactoryService : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private RoadView _roadPrefab;
        [SerializeField] private TargetView _targetPrefab;
        [SerializeField] private ObstacleView _obstaclePrefab;
        [SerializeField] private BulletView _bulletPrefab;
        [SerializeField] private GateView _gatePrefab;
        
        public Factory<PlayerView> players { get; private set; }
        public Factory<RoadView> roads { get; private set; }
        public Factory<TargetView> target { get; private set; }
        public Factory<ObstacleView> obstacle { get; private set; }
        public Factory<BulletView> bullet { get; private set; }
        public Factory<GateView> gate { get; private set; }




        private void Awake()
        {
            players = new Factory<PlayerView>(_playerPrefab, 1);
            roads = new Factory<RoadView>(_roadPrefab, 1);
            target = new Factory<TargetView>(_targetPrefab, 1);
            gate = new Factory<GateView>(_gatePrefab, 1);
            obstacle = new Factory<ObstacleView>(_obstaclePrefab, 200);
            bullet = new Factory<BulletView>(_bulletPrefab, 1);
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
