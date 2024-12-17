using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guitar
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource string1;
        public AudioSource string2;
        public AudioSource string3;
        public AudioSource string4;
        public AudioSource string5;
        public AudioSource string6;

        void Start()
        {
            // You can set the volume here or adjust it as needed
            string1.volume = 1.0f; // Adjust volume level as needed
            string2.volume = 1.0f; // Adjust volume level as needed
            string3.volume = 1.0f; // Adjust volume level as needed
            string4.volume = 1.0f; // Adjust volume level as needed
            string5.volume = 1.0f; // Adjust volume level as needed
            string6.volume = 1.0f; // Adjust volume level as needed
        }
    }
}

