using System;
using UnityEngine;
using System.Collections.Generic;

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
        }

        // Update
        private void Update()
        {
            // Find current chord/note values every frame
            UpdateChord();
            UpdateNotes();

            Debug.Log(currentChord);
        }

        // Update Methods
        private void UpdateChord()
        {
            // Retrieve current chord from ChordManager
            currentChord = chordManager.GetCurrentChord();
            if (string.IsNullOrEmpty(currentChord))
                currentChord = "default"; // Default chord if current chord is null or empty
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
