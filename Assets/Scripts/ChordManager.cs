using UnityEngine;

namespace guitar
{
    public class ChordManager : MonoBehaviour
    {
        // Variable to hold the current chord
        private string currentChord = "default";

        // Set the current chord
        public void SetCurrentChord(string chordName)
        {
            currentChord = chordName;
            Debug.Log("Current chord set to: " + currentChord);
        }

        // Retrieve the current chord
        public string GetCurrentChord()
        {
            return currentChord;
        }
    }
}
