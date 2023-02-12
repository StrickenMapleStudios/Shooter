using UnityEngine;
using Game.ScriptableObjects;

namespace Game.Player {

    public class InputHandler : MonoBehaviour {

        private void Update() {
            switch (GameStateScriptableObject.current.GameState) {
                case (GameState.Playing):
                    if (Input.GetKeyDown(KeyCode.Escape)) {
                        GameEventChannel.current.OnGameStateChanged.Invoke(GameState.Paused);
                    }
                    break;
                case (GameState.Paused):
                    if (Input.GetKeyDown(KeyCode.Escape)) {
                        GameEventChannel.current.OnGameStateChanged.Invoke(GameState.Resume);
                    }
                    break;
            }
        }
    }
}