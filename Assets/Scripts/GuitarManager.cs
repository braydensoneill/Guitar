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
        public TextMeshProUGUI currentString1Text;
        public TextMeshProUGUI currentString2Text;
        public TextMeshProUGUI currentString3Text;
        public TextMeshProUGUI currentString4Text;
        public TextMeshProUGUI currentString5Text;
        public TextMeshProUGUI currentString6Text;

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
            currentString1Text.text = 0.ToString();
            currentString2Text.text = 0.ToString();
            currentString3Text.text = 0.ToString();
            currentString4Text.text = 0.ToString();
            currentString5Text.text = 0.ToString();
            currentString6Text.text = 0.ToString();
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

            // TBD (cleanup) - Display the x value for each string using text
            currentString1Text.text = currentNotes[0].Item1.ToString();
            currentString2Text.text = currentNotes[1].Item1.ToString();
            currentString3Text.text = currentNotes[2].Item1.ToString();
            currentString4Text.text = currentNotes[3].Item1.ToString();
            currentString5Text.text = currentNotes[4].Item1.ToString();
            currentString6Text.text = currentNotes[5].Item1.ToString();
        }
    }
}
