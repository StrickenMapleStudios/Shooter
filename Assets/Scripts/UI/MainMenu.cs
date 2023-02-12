using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Game;

namespace UI {

    public class MainMenu : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button play;
        [SerializeField] private Button options;
        [SerializeField] private Button exit;

        private void OnEnable() {
            play.onClick.AddListener(OnPlayClicked);
            options.onClick.AddListener(OnOptionsClicked);
            exit.onClick.AddListener(OnExitClicked);

            GameEventChannel.current.OnBitMaskChanged.Invoke(GameCanvas.MainMenu);
        }

        private void OnDisable() {
            play.onClick.RemoveListener(OnPlayClicked);
            options.onClick.RemoveListener(OnOptionsClicked);
            exit.onClick.RemoveListener(OnExitClicked);
        }

        public void OnPlayClicked() {
            GameEventChannel.current.OnBitMaskChanged.Invoke(GameCanvas.Presets);
        }

        public void OnOptionsClicked() {
            GameEventChannel.current.OnBitMaskChanged.Invoke(GameCanvas.Options);
        }

        public void OnExitClicked() {
            #if UNITY_STANDALONE
                Application.Quit();
            #endif
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}
