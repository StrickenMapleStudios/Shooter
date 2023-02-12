using UnityEngine;

namespace Game {

    public class TimeScaler : MonoBehaviour
    {
        private void OnEnable() {
            GameEventChannel.current.OnGameStateChanged.AddListener(OnGameStateChanged);
        }

        private void OnDisable() {
            GameEventChannel.current.OnGameStateChanged.RemoveListener(OnGameStateChanged);
        }

        private void OnGameStateChanged(GameState state) {
            switch (state) {
                case GameState.Paused:
                    Time.timeScale = 0;
                    break;
                default:
                    Time.timeScale = 1;
                    break;
            }
        }
    }
}
