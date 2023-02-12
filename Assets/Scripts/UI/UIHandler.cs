using UnityEngine;
using Game;

namespace UI {

    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private GameCanvas gameCanvas;

        private Canvas canvas;
        private CanvasGroup canvasGroup;

        private bool isActive = false;

        private bool IsActive {
            get => isActive;
            set {
                isActive = value;
                canvasGroup.alpha = value ? 1 : 0;
                canvasGroup.interactable = value;
            }
        }

        private void Awake() {
            canvas = GetComponent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable() {
            GameEventChannel.current.OnBitMaskChanged.AddListener(ShowCanvas);
        }

        private void OnDisable() {
            GameEventChannel.current.OnBitMaskChanged.RemoveListener(ShowCanvas);
        }

        private void ShowCanvas(GameCanvas bitMask) {
            IsActive = (gameCanvas & bitMask) != 0;
            canvas.sortingOrder = IsActive ? 1 : 0;
        }
    }
}