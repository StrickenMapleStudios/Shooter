using UnityEngine;
using UnityEngine.UI;
using Game.ScriptableObjects;
using TMPro;
using UnityEngine.SceneManagement;

namespace UI {

    public class PresetsUI : MonoBehaviour
    {
        [Header("Presets")]
        [SerializeField] private TimersScriptableObject timersScriptableObject;
        [SerializeField] private TargetScriptableObject targetLifetimeScriptableObject;
        [SerializeField] private ShootingScriptableObject shootingCooldownScriptableObject;

        [Header("Input fields")]
        [SerializeField] private TMP_InputField gametime;
        [SerializeField] private TMP_InputField targetLifetime;
        [SerializeField] private TMP_InputField shootingCooldown;

        [Header("Button")]
        [SerializeField] private Button okButton;

        private void OnEnable() {
            okButton.onClick.AddListener(OnOkClicked);
            SetInputFields();
        }

        private void OnDisable() {
            okButton.onClick.RemoveListener(OnOkClicked);
        }

        private void SetInputFields() {
            gametime.text = $"{timersScriptableObject.GameplayTime}";
            targetLifetime.text = $"{targetLifetimeScriptableObject.TargetLifetime}";
            shootingCooldown.text = $"{shootingCooldownScriptableObject.ShootingCooldown}";
        }

        private void OnOkClicked() {
            UpdatePresets();
            SceneManager.LoadScene("Game");
        }

        private void UpdatePresets() {
            timersScriptableObject.GameplayTime = float.Parse(gametime.text);
            targetLifetimeScriptableObject.TargetLifetime = float.Parse(targetLifetime.text);
            shootingCooldownScriptableObject.ShootingCooldown = float.Parse(shootingCooldown.text);
        }
    }
}
