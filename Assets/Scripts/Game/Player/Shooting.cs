using UnityEngine;
using Game.ScriptableObjects;
using System.Collections;

namespace Game.Player {

    public class Shooting : MonoBehaviour
    {
        [SerializeField] private ShootingScriptableObject shootingScriptableObject;

        [SerializeField] private LayerMask _layerMask;

        private bool shootingCooldown = false;
        

        private void Update() {
            if (!shootingCooldown) {
                if (Input.GetMouseButtonDown(0)) {
                    Shoot();
                }
            }
        }

        private void Shoot() {
            GameEventChannel.current.OnShooting.Invoke();
            
            StartCoroutine(ShootingCooldown());

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, _layerMask)) {
                GameEventChannel.current.OnTargetShooted.Invoke();
            }
        }

        private IEnumerator ShootingCooldown() {
            shootingCooldown = true;
            yield return new WaitForSeconds(shootingScriptableObject.ShootingCooldown);
            shootingCooldown = false;

        }
    }
}