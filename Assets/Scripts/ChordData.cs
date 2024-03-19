using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

namespace guitar
{
    public class ChordData : MonoBehaviour
    {
        [System.Serializable]
        public class Note
        {
            public int noteX;
            public int noteY;
            public AudioClip audioClip;
        }

        [System.Serializable]
        public class Chord
        {
            public string name;
            public List<Note> notes = new List<Note>();
        }

        public List<Chord> chords = new List<Chord>();

        // Method to initialize example chords
        void Awake()
        {
            AddDefaultChord();
            AddMajorChords();
            AddMinorChords();
        }

        // Method to add a new chord
        public void AddChord(string _name, List<Note> _notes)
        {
            Chord newChord = new Chord { name = _name, notes = _notes };

            foreach (Note note in _notes)
            {
                // For some reason the parent folder needds to be 'Resources' when finding audio files
                note.audioClip = Resources.Load<AudioClip>(GetAudioClipPath(note.noteX, note.noteY));
            }

            chords.Add(newChord);
        }

        // Method to retrieve a chord by name
        public Chord GetChord(string _name)
        {
            return chords.Find(chord => chord.name == _name);
        }

        // Method to construct the audio clip path
        public string GetAudioClipPath(int _noteX, int _noteY)
        {   
            // Ignore the resources folder, start path at notes
            string location = "Notes/X" + _noteX.ToString() + "/";
            string name = "X" + _noteX.ToString() + "Y" + _noteY.ToString();
            string path = location + name;
            return path;
        }

        private void AddDefaultChord()
        {
            AddChord("default", new List<Note> {
                new Note { noteX = 0, noteY = 1 },
                new Note { noteX = 0, noteY = 2 },
                new Note { noteX = 0, noteY = 3 },
                new Note { noteX = 0, noteY = 4 },
                new Note { noteX = 0, noteY = 5 },
                new Note { noteX = 0, noteY = 6 }
            });
        }

        private void AddMajorChords()
        {
            AddChord("G", new List<Note> {
                new Note { noteX = 3, noteY = 1 },
                new Note { noteX = 2, noteY = 2 },
                new Note { noteX = 0, noteY = 3 },
                new Note { noteX = 0, noteY = 4 },
                new Note { noteX = 3, noteY = 5 },
                new Note { noteX = 3, noteY = 6 }
            });

            AddChord("F", new List<Note> {
                new Note { noteX = 1, noteY = 1 },
                new Note { noteX = 3, noteY = 2 },
                new Note { noteX = 3, noteY = 3 },
                new Note { noteX = 2, noteY = 4 },
                new Note { noteX = 1, noteY = 5 },
                new Note { noteX = 0, noteY = 6 }
            });

            AddChord("E", new List<Note> {
                new Note { noteX = 0, noteY = 1 },
                new Note { noteX = 1, noteY = 2 },
                new Note { noteX = 2, noteY = 3 },
                new Note { noteX = 2, noteY = 4 },
                new Note { noteX = 0, noteY = 5 },
                new Note { noteX = 0, noteY = 6 }
            });
            // Add other major chords here
        }

        private void AddMinorChords()
        {
            AddChord("Em", new List<Note> {
                new Note { noteX = 0, noteY = 1 },
                new Note { noteX = 2, noteY = 2 },
                new Note { noteX = 2, noteY = 3 },
                new Note { noteX = 0, noteY = 4 },
                new Note { noteX = 0, noteY = 5 },
                new Note { noteX = 0, noteY = 6 }
            });
        }
    }
}
