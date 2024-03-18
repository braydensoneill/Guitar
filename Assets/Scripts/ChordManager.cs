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
            currentChord = _chord;
            Debug.Log("Current chord: " + currentChord);
            // Update UI text
            currentChordText.text = currentChord;
        }

        // Method to get current chord
        public string GetCurrentChord()
        {
            return currentChord; // Return current chord
        }
    }
}
