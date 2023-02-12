using UnityEngine;

namespace Game.ScriptableObjects {
    
    [CreateAssetMenu(fileName = "Timers", menuName = "ScriptableObjects/Timers")]
    public class TimersScriptableObject : ScriptableObject
    {
        [SerializeField] private float startTimer = 3;
        [SerializeField] private float gameplayTime = 30;

        public float StartTimer {
            get => startTimer;
            set => startTimer = value;
        }
        public float GameplayTime {
            get => gameplayTime;
            set => gameplayTime = value;        
        }
    }
}