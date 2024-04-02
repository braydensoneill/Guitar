using UnityEngine;
using UnityEngine.EventSystems;

namespace guitar
{
    public class StrumButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private bool canActivate = true;

        private StringManager stringManager; // Reference to StringManager script

        // This method is called when the GameObject is enabled
        void OnEnable()
        {
            // Attempt to find the StringManager script in the hierarchy
            stringManager = GetComponentInParent<StringManager>();

            // Check if the StringManager script was found
            if (stringManager == null)
                Debug.LogError("StringManager script not found in the scene.");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (Input.GetMouseButton(0) && canActivate)
            {
                ActivateButton();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            canActivate = true; // Allow button to activate again when mouse re-enters
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ActivateButton();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            canActivate = true; // Allow button to activate again when mouse button is released
        }

        void ActivateButton()
        {
            if (stringManager != null)
            {
                stringManager.PlayStringSound(); // Invoke PlayStringSound method from StringManager
                canActivate = false; // Prevent further activations until the mouse exits the button area
            }
        }
    }
}
