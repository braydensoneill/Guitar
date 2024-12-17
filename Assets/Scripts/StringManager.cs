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

        void Start()
        {
            ChordData chordData = FindFirstObjectByType<ChordData>();
            ChordData.Chord defaultChord = chordData.GetChord("default");

            defaultNoteX = defaultChord.notes[stringNumber - 1].noteX;
            defaultNoteY = defaultChord.notes[stringNumber - 1].noteY;
            defaultNoteAudio = defaultChord.notes[stringNumber - 1].audioClip;

            currentNoteX = defaultNoteX;
            currentNoteY = defaultNoteY;
            currentNoteAudio = defaultNoteAudio;
        }

        // Method to play the string sound
        public void PlayStringSound()
        {
            if (currentNoteAudio != null)
            {
                audioSource.Stop(); //TEMP - should they be allowed to overlap?
                audioSource.PlayOneShot(currentNoteAudio);
            }
            else
            {
                Debug.LogWarning("Current note audio is null. Cannot play string sound.");
            }
        }

        public Tuple<int, int> GetCurrentNote(string currentChord)
        {
            ChordData chordData = FindFirstObjectByType<ChordData>();
            ChordData.Chord chord = chordData.GetChord(currentChord);

            currentNoteX = chord.notes[stringNumber - 1].noteX;
            currentNoteY = chord.notes[stringNumber - 1].noteY;
            currentNoteAudio = chord.notes[stringNumber - 1].audioClip;

            return Tuple.Create(currentNoteX, currentNoteY);
        }
    }
}
