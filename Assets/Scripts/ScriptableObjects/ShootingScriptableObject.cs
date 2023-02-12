using UnityEngine;

namespace Game.ScriptableObjects {
    
    [CreateAssetMenu(fileName = "Shooting", menuName = "ScriptableObjects/Shooting")]
    public class ShootingScriptableObject : ScriptableObject
    {
        [SerializeField] private float shootingCooldown = .5f;

        public float ShootingCooldown {
            get => shootingCooldown;
            set => shootingCooldown = value;
        }
    }
}