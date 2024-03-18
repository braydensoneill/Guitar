using UnityEngine;
using TMPro;

namespace guitar
{
    public class ChordManager : MonoBehaviour
    {
        // Current chord
        private string currentChord;

        // TextMeshPro object to display current chord
        public TextMeshProUGUI currentChordText;

        // Method to set current chord
        public void SetChord(string _chord)
        {
            // Update the current chord
            if(currentChord != "default")
            {
                currentChord = "default"; // Reset to default if not already default
                currentChordText.text = " "; // Clear display
            }  

            else
            {
                currentChord = _chord; // Set current chord
                currentChordText.text = currentChord; // Display current chord
            }
        }

        // Method to get current chord
        public string GetCurrentChord()
        {
            return currentChord; // Return current chord
        }
    }
}
