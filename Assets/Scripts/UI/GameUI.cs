using UnityEngine;
using Game;

namespace UI {

    public class GameUI : MonoBehaviour
    {
        private void OnEnable() {
            GameEventChannel.current.OnGameStateChanged.AddListener(SwitchGameState);
        }

        private void OnDisable() {
            GameEventChannel.current.OnGameStateChanged.RemoveListener(SwitchGameState);
        }

        public void SwitchGameState(GameState state) {
            GameCanvas bitMask = 0;
            switch (state) {
                case GameState.Ready:
                    bitMask = GameCanvas.StartTimer;
                    break;
                case GameState.StartGame:
                case GameState.Playing:
                    bitMask = GameCanvas.HUD | GameCanvas.AimCanvas;
                    break;
                case GameState.Paused:
                    bitMask = GameCanvas.HUD | GameCanvas.PauseMenu;
                    break;
                case GameState.GameOver:
                    bitMask = GameCanvas.GameOver;
                    break;
            }
            GameEventChannel.current.OnBitMaskChanged.Invoke(bitMask);
        }

    }
}