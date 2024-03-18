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

        public GameObject[] strings;

        // Current chord
        [SerializeField] private string currentChord;

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

        private void Update()
        {
            Debug.Log(currentChord);
            // Find current chord/note values every frame
            GetCurrentChord();
            GetCurrentNotes();
        }

        private void GetCurrentChord()
        {
            // Retrieve current chord from ChordManager
            currentChord = chordManager.GetCurrentChord();
            if (string.IsNullOrEmpty(currentChord))
            {
                currentChord = "default";
            }
        }

        private void GetCurrentNotes()
        {
            // Retrieve current notes from StringManagers
            for (int i = 0; i < strings.Length; i++)
            {
                currentNotes[i] = strings[i].GetComponent<StringManager>().GetCurrentNote(currentChord);
            }
        }

        // Define other methods and variables as needed
    }
}
