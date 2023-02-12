using UnityEngine;
using Game.ScriptableObjects;

namespace Game {

    public class Game : MonoBehaviour
    {
        [SerializeField] private GameStateScriptableObject gameStateScriptableObject;

        private GameState prevGameState;

        private int score;
        private int hitTargetCount;
        private int shotCount;
        

        public static GameState GameState {
            get => GameStateScriptableObject.current.GameState;
            private set {
                GameStateScriptableObject.current.GameState = value;
                GameEventChannel.current.OnGameStateChanged.Invoke(value);
            }
        }

        public int Score {
            get => score;
            private set {
                score = Mathf.Max(0, value);
                GameEventChannel.current.OnScoreChanged.Invoke(score);
            }
        }
        public int HitTargetCount {
            get => hitTargetCount;
            private set {
                hitTargetCount = value;
                GameEventChannel.current.OnAccuracyChanged.Invoke(hitTargetCount, shotCount);
            }
        }
        public int ShotCount {
            get => shotCount;
            private set {
                shotCount = value;
                GameEventChannel.current.OnAccuracyChanged.Invoke(hitTargetCount, shotCount);
            }
        }

        private void OnEnable() {
            GameEventChannel.current.OnGameStateChanged.AddListener(OnGameStateChanged);
            GameEventChannel.current.OnShooting.AddListener(OnShooting);
            GameEventChannel.current.OnTargetShooted.AddListener(OnTargetShooted);
            GameEventChannel.current.OnTimeout.AddListener(OnTimeout);
        }

        private void OnDisable() {
            GameEventChannel.current.OnGameStateChanged.RemoveListener(OnGameStateChanged);
            GameEventChannel.current.OnTargetShooted.RemoveListener(OnTargetShooted);
            GameEventChannel.current.OnTimeout.RemoveListener(OnTimeout);
        }

        private void OnShooting()
        {
            ShotCount++;
        }

        private void OnTargetShooted()
        {
            Score++;
            HitTargetCount++;
            GameEventChannel.current.OnTargetRequired.Invoke();
        }
        
        private void OnTimeout() {
            Score--;
            GameEventChannel.current.OnTargetRequired.Invoke();
        }

        private void OnGameStateChanged(GameState state) {
            switch (state) {
                case GameState.Ready:

                    break;

                case GameState.StartGame:
                    GameEventChannel.current.OnTargetRequired.Invoke();
                    GameState = GameState.Playing;
                    return;

                case GameState.Resume:
                    GameState = prevGameState;
                    break;


                case GameState.Paused:
                    prevGameState = GameState;
                    break;
                    
                case GameState.GameOver:
                    return;
            }
        }

        private void Start() {
            StartGame();
        }

        private void StartGame() {
            GameState = GameState.Ready;
        }
    }
}
