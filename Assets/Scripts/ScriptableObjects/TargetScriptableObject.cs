using UnityEngine;

namespace Game.ScriptableObjects {
    
    [CreateAssetMenu(fileName = "TargetLifetime", menuName = "ScriptableObjects/TargetLifetime")]
    public class TargetScriptableObject : ScriptableObject
    {

        [SerializeField] private float targetLifetime = 2;

        public float TargetLifetime {
            get => targetLifetime;
            set => targetLifetime = value;
        }
    }
}