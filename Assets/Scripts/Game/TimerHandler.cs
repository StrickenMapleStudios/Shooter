using UnityEngine;
using Game.ScriptableObjects;
using System.Collections;

namespace Game {

    public class TimerHandler : MonoBehaviour
    {
        [SerializeField] private TimersScriptableObject timersPreset;

        private float startTimer;
        private float timer;

        public float StartTimer {
            get => startTimer;
            private set {
                startTimer = value;
                GameEventChannel.current.OnStartTimerChanged.Invoke(value);
                if (value <= 0) {
                    GameEventChannel.current.OnGameStateChanged.Invoke(GameState.StartGame);
                }
            }
        }

        public float Timer {
            get => timer;
            private set {
                timer = value;
                GameEventChannel.current.OnTimerChanged.Invoke(value);
                if (value <= 0) {
                    GameEventChannel.current.OnGameStateChanged.Invoke(GameState.GameOver);
                }
            }
        }
        
        private void OnEnable() {
            GameEventChannel.current.OnGameStateChanged.AddListener(OnGameplayStateChanged);
        }

        private void OnDisable() {
            GameEventChannel.current.OnGameStateChanged.RemoveListener(OnGameplayStateChanged);
        }

        private void OnGameplayStateChanged(GameState state) {
            switch (state) {
                case GameState.Ready:
                    StartCoroutine(StartTimerCountdown());
                    break;
                
                case GameState.StartGame:
                    StartCoroutine(TimerCountdown());
                    break;
            }
        }

        private IEnumerator StartTimerCountdown(float countdownValue = 1) {
            StartTimer = timersPreset.StartTimer;

            while (StartTimer > 0) {
                yield return new WaitForSeconds(countdownValue);
                StartTimer -= countdownValue;
            }
        }

        private IEnumerator TimerCountdown(float countdownValue = 1) {
            Timer = timersPreset.GameplayTime;

            while (Timer > 0) {
                yield return new WaitForSeconds(countdownValue);
                Timer -= countdownValue;
            }
        }
    }
}