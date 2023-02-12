using UnityEngine;

namespace Game.Player {

    public class Rotation : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity;
        [SerializeField] private float mouseSpeed;

        private float mouseX;
        private float mouseY;


        private void Update() {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * mouseSpeed * Time.deltaTime;
            mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity * mouseSpeed * Time.deltaTime;

            if (mouseX != 0 || mouseY != 0) {
                transform.localEulerAngles += new Vector3(mouseY, mouseX, 0);
                /*transform.localEulerAngles = Vector3.MoveTowards(
                    transform.localEulerAngles,
                    transform.localEulerAngles + new Vector3(mouseY, mouseX, 0),
                    0.25f
                );*/
            }
        }
    }
}
