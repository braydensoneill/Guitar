using System;
using UnityEngine;

namespace guitar
{
    public class StringManager : MonoBehaviour
    {
        // Number of string this script is working on   
        public int stringNumber;

        // Reference to central AudioSource
        [SerializeField] private AudioSource audioSource;

        // Default notes
        [SerializeField] private int defaultNoteX;
        [SerializeField] private int defaultNoteY;
        [SerializeField] private AudioClip defaultNoteAudio;

        // Current notes
        [SerializeField] private int currentNoteX;
        [SerializeField] private int currentNoteY;
        [SerializeField] private AudioClip currentNoteAudio;

        // Initialize
        void Start()
        {
            // Reference to GuitarManager script
            GuitarManager guitarManager = FindFirstObjectByType<GuitarManager>();

            // Fetch the default note values from the "null" chord in ChordData
            ChordData chordData = FindFirstObjectByType<ChordData>(); // Assuming there's only one ChordData in the scene
            ChordData.Chord nullChord = chordData.GetChord("default"); // Use "null" chord for default values

            // Set the default note values to those of the "null" chord
            defaultNoteX = nullChord.notes[stringNumber - 1].noteX;
            defaultNoteY = nullChord.notes[stringNumber - 1].noteY;
            defaultNoteAudio = nullChord.notes[stringNumber - 1].audioClip;

            // set the value of the current note to the value of the default note
            currentNoteX = defaultNoteX;
            currentNoteY = defaultNoteY;
            currentNoteAudio = defaultNoteAudio;
        }

        // Method to play the string sound
        public void PlayStringSound()
        {
            if (currentNoteAudio != null)
            {
                Debug.Log("String button pressed");
                // Play the sound using central AudioSource
                audioSource.PlayOneShot(currentNoteAudio);
            }
            else
            {
                Debug.LogWarning("Current note audio is null. Cannot play string sound.");
            }
        }

        // Method to get current note as a tuple
        public Tuple<int, int> GetCurrentNote(string currentChord)
        {
            // Retrieve the chord data
            ChordData chordData = FindFirstObjectByType<ChordData>(); // Assuming there's only one ChordData in the scene
            
            // Retrieve the current chord
            ChordData.Chord chord = chordData.GetChord(currentChord);

            // Retrieve the first note's X and Y values from the current chord
            currentNoteX = chord.notes[stringNumber - 1].noteX;
            currentNoteY = chord.notes[stringNumber - 1].noteY;
            currentNoteAudio = chord.notes[stringNumber - 1].audioClip;
                
            // Return the current note as a tuple
            return Tuple.Create(currentNoteX, currentNoteY);
        }
    }
}
