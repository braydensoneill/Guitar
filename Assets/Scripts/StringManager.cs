using System;
using System.Collections.Generic;
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

        // Queue to manage currently playing sounds
        private Queue<AudioSource> playingQueue = new Queue<AudioSource>();

        // Maximum overlap for this string
        private const int maxOverlap = 3;

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
                // Stop audio that exceeds the maximum overlap
                if (playingQueue.Count >= maxOverlap)
                {
                    AudioSource oldestSource = playingQueue.Dequeue();
                    oldestSource.Stop();
                }

                // Play the new audio
                AudioSource newSource = CreateAudioSource();
                newSource.PlayOneShot(currentNoteAudio);

                // Add the new audio to the queue
                playingQueue.Enqueue(newSource);
            }
            else
            {
                Debug.LogWarning("Current note audio is null. Cannot play string sound.");
            }
        }

        // Helper method to create a new AudioSource
        private AudioSource CreateAudioSource()
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.clip = currentNoteAudio;
            newSource.playOnAwake = false;
            return newSource;
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
