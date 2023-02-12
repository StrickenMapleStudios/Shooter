using UnityEngine;
using UnityEngine.UI;
using Game;
using UnityEngine.SceneManagement;

namespace UI {

    public class PauseHandler : MonoBehaviour
    {
            [Header("Buttons")]
            [SerializeField] private Button resume;
            [SerializeField] private Button restart;
            [SerializeField] private Button mainMenu;

            private void OnEnable() {
                resume.onClick.AddListener(Resume);
                restart.onClick.AddListener(Restart);
                mainMenu.onClick.AddListener(MainMenu);
            }

            private void OnDisable() {
                resume.onClick.RemoveListener(Resume);
                restart.onClick.RemoveListener(Restart);
                mainMenu.onClick.RemoveListener(MainMenu);
            }

            private void Resume() {
                GameEventChannel.current.OnGameStateChanged.Invoke(GameState.Resume);
            }

            private void Restart() {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            private void MainMenu() {
                SceneManager.LoadScene("MainMenu");
            }
    }
}
