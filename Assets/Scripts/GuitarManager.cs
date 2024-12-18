using System;
using UnityEngine;
using TMPro;

namespace guitar
{
    public class GuitarManager : MonoBehaviour
    {
        // References
        private StringManager stringManager;

        // Current chord
        [SerializeField] private string currentChord;
        public TextMeshProUGUI currentChordText;

        // Strings
        public GameObject[] strings;

        // Current notes
        [SerializeField] private Tuple<int, int>[] currentNotes;

        // Initialize
        void Start()
        {
            // Initialize Managers
            stringManager = FindFirstObjectByType<StringManager>();

            // Initialize currentNotes array
            currentNotes = new Tuple<int, int>[strings.Length];

            // Set default chord initially
            currentChord = "default";
            currentChordText.text = "/";
            UpdateNotes();
        }

        // Method to change the current chord
        public void ChangeChord(string newChord)
        {
            // Update the current chords state
            currentChord = newChord;
            
            // Update the text that displays the current chord - " " if default chord
            if(currentChord != "default")
                currentChordText.text = currentChord;
            else 
                currentChordText.text = "/";

            // Update notes to adhere to the new current Chord
            UpdateNotes();

            // TEMP - debug message
            Debug.Log($"Chord changed to: {currentChord}");
        }

        private void UpdateNotes()
        {
            // Retrieve current notes from StringManagers
            for (int i = 0; i < strings.Length; i++)
            {
                currentNotes[i] = strings[i].GetComponent<StringManager>().GetCurrentNote(currentChord);
            }
        }
    }
}
