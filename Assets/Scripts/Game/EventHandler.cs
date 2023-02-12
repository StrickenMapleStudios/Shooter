using UnityEngine;

namespace Game {
    
    public class EventHandler : MonoBehaviour
    {
        [SerializeField] private GameEventChannel eventChannel;
        
        public GameEventChannel EventChannel {
            set => eventChannel = value;
        }
    }
}
