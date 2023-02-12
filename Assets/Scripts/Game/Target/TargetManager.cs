using UnityEngine;

namespace Game.Target {

    public class TargetManager : MonoBehaviour
    {
        [SerializeField] private TargetSpawner targetSpawner;
        [SerializeField] private Transform targetHolder;

        private void Awake() {
            targetSpawner.TargetParent = targetHolder;
        }

        private void OnEnable() {
            GameEventChannel.current.OnGameStateChanged.AddListener(OnGameplayStateChanged);
        }

        private void OnDisable() {
            GameEventChannel.current.OnGameStateChanged.RemoveListener(OnGameplayStateChanged);
        }

        private void OnGameplayStateChanged(GameState state) {
            if (state == GameState.GameOver) {
                foreach (Transform target in targetHolder) {
                    Destroy(target.gameObject);
                }
            }
        }
    }
}