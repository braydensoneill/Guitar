using UnityEngine;
using UnityEngine.EventSystems;

namespace guitar
{
    public class ChordButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private bool canActivate = true;

        public string chordName; // The chord to set when this button is clicked.

        private GuitarManager guitarManager;

        // This method is called when the GameObject is enabled
        void OnEnable()
        {
            // Find the first instance of GuitarManager in the scene
            guitarManager = Object.FindFirstObjectByType<GuitarManager>();

            if (guitarManager == null)
            {
                Debug.LogError("GuitarManager not found in the scene.");
            }
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

        private void ActivateButton()
        {
            if (guitarManager != null)
            {
                guitarManager.ChangeChord(chordName);
            }
        }
    }
}
