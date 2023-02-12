using UnityEngine;
using Game.ScriptableObjects;
using System.Collections;

namespace Game.Target {

    public class Target : MonoBehaviour
    {
        [SerializeField] private TargetScriptableObject targetScriptableObject;

        private float lifetime;
        
        private void OnEnable() {
            GameEventChannel.current.OnTargetShooted.AddListener(Destroy);
        }

        private void OnDisable() {
            GameEventChannel.current.OnTargetShooted.RemoveListener(Destroy);
        }

        private void Start() {
            lifetime = targetScriptableObject.TargetLifetime;
            StartCoroutine(Lifetime());
        }

        private IEnumerator Lifetime() {
            yield return new WaitForSeconds(targetScriptableObject.TargetLifetime);
            GameEventChannel.current.OnTimeout.Invoke();
            Destroy();
        }

        private void Destroy() {
            Destroy(gameObject);
        }
    }
}
