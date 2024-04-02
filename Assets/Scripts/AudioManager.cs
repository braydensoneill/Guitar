using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guitar
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource yourAudioSource; // Assign your audio source in the Unity editor

        void Start()
        {
            // You can set the volume here or adjust it as needed
            yourAudioSource.volume = 1.0f; // Adjust volume level as needed
        }
    }
}

