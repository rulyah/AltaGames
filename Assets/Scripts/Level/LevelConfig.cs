using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public Vector3 startTargetPos;
        public Vector3 startPlayerPos;
        public Vector3 gatePos;
        public float spawnRadius = 25.0f;
        public float bulletSpeed = 20.0f;
        public float distanceToVictory = 10.0f;
        public int maxCurrentObstacleCount = 10;
        public Vector3 playerStartSize;
    }
}