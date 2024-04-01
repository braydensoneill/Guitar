using UnityEngine;
using UnityEngine.EventSystems;

namespace guitar
{
    public class StrumButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private bool mouseButtonDown = false;
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
            if (mouseButtonDown && canActivate)
            {
                // Activate button functionality here
                if(stringManager != null)
                    stringManager.PlayStringSound(); // Invoke PlayStringSound method from StringManager

                canActivate = false; // Prevent further activations until the mouse exits the button area
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            canActivate = true; // Allow button to activate again when mouse re-enters
        }

        void Update()
        {
            // Check if the left mouse button is held down
            if (Input.GetMouseButtonDown(0))
            {
                mouseButtonDown = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                mouseButtonDown = false;
            }
        }
    }
}
