using UnityEngine;

namespace Game.ScriptableObjects {

    [CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObjects/GameState")]
    public class GameStateScriptableObject : ScriptableObject
    {
        public static GameStateScriptableObject current { get; private set; }

        [SerializeField] private GameState gameState;

        public GameState GameState {
            get => gameState;
            set => gameState = value;
        }

        private void OnEnable() {
            current = this;
        }

        
    }
}
