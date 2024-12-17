using System;
using UnityEngine;

namespace guitar
{
    public class GuitarManager : MonoBehaviour
    {
        // References to ChordManager and StringManager
        private ChordManager chordManager;
        private StringManager stringManager;

        // Current chord
        [SerializeField] private string currentChord;

        // Strings
        public GameObject[] strings;

        // Current notes
        [SerializeField] private Tuple<int, int>[] currentNotes;

        // Initialize
        void Start()
        {
            // Find and initialize ChordManager and StringManagers
            chordManager = FindAnyObjectByType<ChordManager>();
            stringManager = FindFirstObjectByType<StringManager>();

            // Initialize currentNotes array
            currentNotes = new Tuple<int, int>[strings.Length];

            // Set default chord initially
            currentChord = "default";
            UpdateNotes();
        }

        // Method to change the current chord
        public void ChangeChord(string newChord)
        {
            currentChord = newChord;
            UpdateNotes();
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
