using UnityEngine;
using Game;
using UI;

namespace Editor {

    [ExecuteInEditMode]
    public class UIHandler : MonoBehaviour
    {
        private GameState gameplayState;
        [SerializeField] private GameUI gameplayUI;

        [SerializeField] private GameState GameplayState {
            get => gameplayState;
            set => gameplayUI.SwitchGameState(gameplayState);
        }
        

    }
}
