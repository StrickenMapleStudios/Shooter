using UnityEngine;
using TMPro;
using Game;

namespace UI {

    public class StartTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timer;

        private float Timer {
            set {
                timer.text = Mathf.Round(value).ToString();
            }
        }

        private void OnEnable() {
            GameEventChannel.current.OnStartTimerChanged.AddListener(UpdateStartTimer);
        }
        
        private void OnDisable() {
            GameEventChannel.current.OnStartTimerChanged.RemoveListener(UpdateStartTimer);
        }

        private void UpdateStartTimer(float value)
        {
            Timer = value;
        }
    }
}