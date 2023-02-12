using UnityEngine;
using TMPro;
using System;
using Game;

namespace UI {
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private TextMeshProUGUI accuracy;


        private float Timer {
            set => timer.text = string.Format("{0}:{1}",
                ((int) value / 60).ToString(),
                ((int) value % 60).ToString()
            );
        }

        private int Score {
            set => score.text = $"{value.ToString()}";
        }

        private float Accuracy {
            set => accuracy.text = $"{value}";
        }

        private void OnEnable() {
            GameEventChannel.current.OnTimerChanged.AddListener(UpdateTimer);
            GameEventChannel.current.OnScoreChanged.AddListener(UpdateScore);
            GameEventChannel.current.OnAccuracyChanged.AddListener(UpdateAccuracy);
        }

        private void OnDisable() {
            GameEventChannel.current.OnTimerChanged.RemoveListener(UpdateTimer);
            GameEventChannel.current.OnScoreChanged.RemoveListener(UpdateScore);
            GameEventChannel.current.OnAccuracyChanged.RemoveListener(UpdateAccuracy);
        }

        private void UpdateTimer(float value) {
            Timer = (float) Math.Ceiling(value);
        }

        private void UpdateScore(int value) {
            Score = value;
        }

        private void UpdateAccuracy(int hitTargetCount, int shotCount) {
            Accuracy = Mathf.Round((float) hitTargetCount / shotCount * 100);
        }
    }
}
