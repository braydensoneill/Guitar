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

        // Current Guitar Info text fields
        public TextMeshProUGUI currentChordText;

        // Strings
        public GameObject[] strings;

        // Current Guitar Info text fields
        public TextMeshProUGUI[] currentStringTexts;

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
            ResetCurrentStringText();
            UpdateNotes();
        }

        // Method to change the current chord
        public void ChangeChord(string newChord)
        {
            // Update the current chords state
            currentChord = newChord;
            
            // Update the text that displays the current chord
            currentChordText.text = (currentChord != "default") ? currentChord : "/";

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

            // Update the text for each string
            for (int i = 0; i < currentStringTexts.Length; i++)
            {
                // Update string text with the current note's x value
                currentStringTexts[i].text = currentNotes[i].Item1.ToString();
            }
        }

        private void ResetCurrentStringText()
        {
            // Reset all string text fields to "0" initially
            foreach (var textField in currentStringTexts)
            {
                textField.text = "0";
            }
        }
    }
}
