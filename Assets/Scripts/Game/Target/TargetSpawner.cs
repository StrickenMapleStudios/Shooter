using UnityEngine;

namespace Game.Target {
    public class TargetSpawner : MonoBehaviour
    {

        [SerializeField] private Target targetPrefab;
        [SerializeField] private Transform[] targetAreas;
        
        private Transform targetParent;
        public Transform TargetParent {
            set => targetParent = value;
        }

        private void OnEnable() {
            GameEventChannel.current.OnTargetRequired.AddListener(SpawnTarget);
        }

        private void OnDisable() {
            GameEventChannel.current.OnTargetRequired.RemoveListener(SpawnTarget);
        }

        private Transform GetRandomArea() {
            return targetAreas[Random.Range(0, targetAreas.Length)];
        }

        private Vector3 GetRandomPosition(Transform area) {
            return area.position + new Vector3(
                Random.Range(-area.lossyScale.x / 2, area.lossyScale.x / 2),
                Random.Range(-area.lossyScale.y / 2, area.lossyScale.y / 2),
                Random.Range(-area.lossyScale.z / 2, area.lossyScale.z / 2)
            );
        }

        private void SpawnTarget() {
            Target target = Instantiate(targetPrefab, GetRandomPosition(GetRandomArea()), Quaternion.identity, targetParent);
        }

    }
}

