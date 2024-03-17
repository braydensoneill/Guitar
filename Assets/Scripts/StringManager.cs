using System;
using UnityEngine;

namespace guitar
{
    public class StringManager : MonoBehaviour
    {
        // Reference to central AudioSource
        public AudioSource audioSource;

        // Default notes
        [SerializeField] private int defaultNoteX;
        [SerializeField] private int defaultNoteY;
        public AudioClip defaultNoteAudio;

        // Current notes
        [SerializeField] private int currentNoteX;
        [SerializeField] private int currentNoteY;
        [SerializeField] private AudioClip currentNoteAudio;

        // Initialize
        void Start()
        {
            // Initialize current note values to default
            currentNoteX = defaultNoteX;
            currentNoteY = defaultNoteY;
            currentNoteAudio = defaultNoteAudio;
        }

        // Method to play the string sound
        public void PlayStringSound()
        {
            Debug.Log("String button pressed");
            // Play the sound using central AudioSource
            audioSource.PlayOneShot(currentNoteAudio);
        }

        // Method to set current note
        public void SetCurrentNote(int x, int y)
        {
            currentNoteX = x;
            currentNoteY = y;
        }

        // Method to get current note as a tuple
        public Tuple<int,int> GetCurrentNote()
        {
            return Tuple.Create(currentNoteX, currentNoteY);
        }
    }
}
