using UnityEngine;

namespace guitar
{
    public class ChordButton : MonoBehaviour
    {
        [Tooltip("Name of the chord this button sets.")]
        public string chordName; // The chord to set when this button is clicked.

        private GuitarManager guitarManager;

        void Start()
        {
            // Find the first instance of GuitarManager in the scene
            guitarManager = Object.FindFirstObjectByType<GuitarManager>();

            if (guitarManager == null)
            {
                Debug.LogError("GuitarManager not found in the scene.");
            }
        }

        // This method is called when the button is clicked
        public void OnButtonClick()
        {
            if (guitarManager != null)
            {
                guitarManager.ChangeChord(chordName);
            }
        }
    }
}
