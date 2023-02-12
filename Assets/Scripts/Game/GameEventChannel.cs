using UnityEngine;
using UnityEngine.Events;
using UI;

namespace Game {

    [CreateAssetMenu(fileName = "GameEventChannel", menuName = "Channels/GameEvents", order = 0)]
    public class GameEventChannel : ScriptableObject
    {
        public static GameEventChannel current;

        [Header("Game")]
        public UnityEvent<GameState> OnGameStateChanged = new UnityEvent<GameState>();
        public UnityEvent OnShooting = new UnityEvent();
        public UnityEvent OnTargetShooted = new UnityEvent();
        public UnityEvent OnTargetRequired = new UnityEvent();
        public UnityEvent OnTimeout  = new UnityEvent();

        [Header("UI")]
        public UnityEvent<GameCanvas> OnBitMaskChanged = new UnityEvent<GameCanvas>();
        public UnityEvent<float> OnStartTimerChanged = new UnityEvent<float>();
        public UnityEvent<float> OnTimerChanged = new UnityEvent<float>();
        public UnityEvent<int> OnScoreChanged = new UnityEvent<int>();
        public UnityEvent<int, int> OnAccuracyChanged = new UnityEvent<int, int>();
        
        private void OnEnable() {
            current = this;
        }
    }
}

