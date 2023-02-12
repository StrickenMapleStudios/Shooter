using UnityEngine;
using Game;

namespace UI {

    [RequireComponent(typeof(Animator))]
    public class Cooldown : MonoBehaviour
    {
        private Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        private void OnEnable() {
            GameEventChannel.current.OnShooting.AddListener(Animate);
        }

        private void OnDisable() {
            GameEventChannel.current.OnShooting.AddListener(Animate);
        }

        private void Animate() {
            animator.SetTrigger("Cooldown");
        }
    }
}
