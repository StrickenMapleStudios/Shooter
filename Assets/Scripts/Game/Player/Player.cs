using UnityEngine;

namespace Game.Player {

    [RequireComponent(typeof(Rotation))]
    [RequireComponent(typeof(Shooting))]
    [RequireComponent(typeof(InputHandler))]
    [RequireComponent(typeof(AudioSource))]
    public class Player : MonoBehaviour
    {
        private Rotation rotation;
        private Shooting shooting;
        private AudioSource audioSource;


        private void Awake() {
            rotation = GetComponent<Rotation>();
            shooting = GetComponent<Shooting>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable() {
            EnableControl(false);
            GameEventChannel.current.OnGameStateChanged.AddListener(OnGameplayStateChanged);
            GameEventChannel.current.OnShooting.AddListener(OnShooting);
        }

        private void OnDisable() {
            GameEventChannel.current.OnGameStateChanged.RemoveListener(OnGameplayStateChanged);
            GameEventChannel.current.OnShooting.RemoveListener(OnShooting);
        }

        private void OnGameplayStateChanged(GameState state) {
            switch (state) {
                case GameState.Ready:
                    EnableControl(false);
                    ShowCursor(false);
                    break;
                case GameState.StartGame:
                case GameState.Playing:
                    EnableControl(true);
                    ShowCursor(false);
                    break;
                case GameState.Paused:
                case GameState.GameOver:
                    EnableControl(false);
                    ShowCursor(true);
                    break;
            }
        }

        private void OnShooting() {
            audioSource.Play();
        }

        private void EnableControl(bool value) {
            rotation.enabled = shooting.enabled = value;
        }

        private void ShowCursor(bool value) {
            Cursor.lockState = value ?
                CursorLockMode.None :
                CursorLockMode.Locked;
        }
    }
}
