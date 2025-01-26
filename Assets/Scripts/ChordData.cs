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
            public int noteX; // determines fret
            public int noteY; // determines string
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
            // Order -> See wheel

            AddChord("C", new List<Note> {
                new Note { noteX = 0, noteY = 1 },
                new Note { noteX = 3, noteY = 2 },
                new Note { noteX = 2, noteY = 3 },
                new Note { noteX = 0, noteY = 4 },
                new Note { noteX = 1, noteY = 5 },
                new Note { noteX = 0, noteY = 6 }
            });

            AddChord("G", new List<Note> {
                new Note { noteX = 3, noteY = 1 },
                new Note { noteX = 2, noteY = 2 },
                new Note { noteX = 0, noteY = 3 },
                new Note { noteX = 0, noteY = 4 },
                new Note { noteX = 0, noteY = 5 },
                new Note { noteX = 3, noteY = 6 }
            });

            AddChord("D", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = -1, noteY = 2 },
                new Note { noteX = 0, noteY = 3 },
                new Note { noteX = 2, noteY = 4 },
                new Note { noteX = 3, noteY = 5 },
                new Note { noteX = 2, noteY = 6 }
            });

            AddChord("A", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 0, noteY = 2 },
                new Note { noteX = 2, noteY = 3 },
                new Note { noteX = 2, noteY = 4 },
                new Note { noteX = 2, noteY = 5 },
                new Note { noteX = 0, noteY = 6 }
            });

            AddChord("E", new List<Note> {
                new Note { noteX = 0, noteY = 1 },
                new Note { noteX = 2, noteY = 2 },
                new Note { noteX = 2, noteY = 3 },
                new Note { noteX = 1, noteY = 4 },
                new Note { noteX = 0, noteY = 5 },
                new Note { noteX = 0, noteY = 6 }
            });

            AddChord("B", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 2, noteY = 2 },
                new Note { noteX = 4, noteY = 3 },
                new Note { noteX = 4, noteY = 4 },
                new Note { noteX = 4, noteY = 5 },
                new Note { noteX = 2, noteY = 6 }
            });

            AddChord("Gb", new List<Note> {
                new Note { noteX = 2, noteY = 1 },
                new Note { noteX = 4, noteY = 2 },
                new Note { noteX = 4, noteY = 3 },
                new Note { noteX = 3, noteY = 4 },
                new Note { noteX = 2, noteY = 5 },
                new Note { noteX = 2, noteY = 6 }
            });

            AddChord("Db", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 4, noteY = 2 },
                new Note { noteX = 6, noteY = 3 },
                new Note { noteX = 6, noteY = 4 },
                new Note { noteX = 6, noteY = 5 },
                new Note { noteX = 4, noteY = 6 }
            });

            AddChord("Ab", new List<Note> {
                new Note { noteX = 4, noteY = 1 },
                new Note { noteX = 6, noteY = 2 },
                new Note { noteX = 6, noteY = 3 },
                new Note { noteX = 5, noteY = 4 },
                new Note { noteX = 4, noteY = 5 },
                new Note { noteX = 4, noteY = 6 }
            });
            
            AddChord("Eb", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 6, noteY = 2 },
                new Note { noteX = 8, noteY = 3 },
                new Note { noteX = 8, noteY = 4 },
                new Note { noteX = 8, noteY = 5 },
                new Note { noteX = 6, noteY = 6 }
            });

            AddChord("Bb", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 1, noteY = 2 },
                new Note { noteX = 3, noteY = 3 },
                new Note { noteX = 3, noteY = 4 },
                new Note { noteX = 3, noteY = 5 },
                new Note { noteX = 1, noteY = 6 }
            });

            AddChord("F", new List<Note> {
                new Note { noteX = 1, noteY = 1 },
                new Note { noteX = 3, noteY = 2 },
                new Note { noteX = 3, noteY = 3 },
                new Note { noteX = 2, noteY = 4 },
                new Note { noteX = 1, noteY = 5 },
                new Note { noteX = 1, noteY = 6 }
            });
        }

        private void AddMinorChords()
        {
            // Order -> See wheel

            AddChord("Am", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 0, noteY = 2 },
                new Note { noteX = 2, noteY = 3 },
                new Note { noteX = 2, noteY = 4 },
                new Note { noteX = 1, noteY = 5 },
                new Note { noteX = 0, noteY = 6 }
            });

            AddChord("Em", new List<Note> {
                new Note { noteX = 0, noteY = 1 },
                new Note { noteX = 2, noteY = 2 },
                new Note { noteX = 2, noteY = 3 },
                new Note { noteX = 0, noteY = 4 },
                new Note { noteX = 0, noteY = 5 },
                new Note { noteX = 0, noteY = 6 }
            });

            AddChord("Bm", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 2, noteY = 2 },
                new Note { noteX = 4, noteY = 3 },
                new Note { noteX = 4, noteY = 4 },
                new Note { noteX = 3, noteY = 5 },
                new Note { noteX = 2, noteY = 6 }
            });

            AddChord("F#m", new List<Note> {
                new Note { noteX = 2, noteY = 1 },
                new Note { noteX = 4, noteY = 2 },
                new Note { noteX = 4, noteY = 3 },
                new Note { noteX = 2, noteY = 4 },
                new Note { noteX = 2, noteY = 5 },
                new Note { noteX = 2, noteY = 6 }
            });

            AddChord("C#m", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 4, noteY = 2 },
                new Note { noteX = 6, noteY = 3 },
                new Note { noteX = 6, noteY = 4 },
                new Note { noteX = 5, noteY = 5 },
                new Note { noteX = 4, noteY = 6 }
            });

            AddChord("G#m", new List<Note> {
                new Note { noteX = 4, noteY = 1 },
                new Note { noteX = 6, noteY = 2 },
                new Note { noteX = 6, noteY = 3 },
                new Note { noteX = 4, noteY = 4 },
                new Note { noteX = 4, noteY = 5 },
                new Note { noteX = 4, noteY = 6 }
            });

            AddChord("D#m", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 6, noteY = 2 },
                new Note { noteX = 8, noteY = 3 },
                new Note { noteX = 8, noteY = 4 },
                new Note { noteX = 6, noteY = 5 },
                new Note { noteX = 6, noteY = 6 }
            });

            AddChord("A#m", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 6, noteY = 2 },
                new Note { noteX = 8, noteY = 3 },
                new Note { noteX = 8, noteY = 4 },
                new Note { noteX = 6, noteY = 5 },
                new Note { noteX = 6, noteY = 6 }
            });

            AddChord("Fm", new List<Note> {
                new Note { noteX = 1, noteY = 1 },
                new Note { noteX = 3, noteY = 2 },
                new Note { noteX = 3, noteY = 3 },
                new Note { noteX = 1, noteY = 4 },
                new Note { noteX = 1, noteY = 5 },
                new Note { noteX = 1, noteY = 6 }
            });

            AddChord("Cm", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 3, noteY = 2 },
                new Note { noteX = 5, noteY = 3 },
                new Note { noteX = 5, noteY = 4 },
                new Note { noteX = 4, noteY = 5 },
                new Note { noteX = 3, noteY = 6 }
            });

            AddChord("Gm", new List<Note> {
                new Note { noteX = 3, noteY = 1 },
                new Note { noteX = 5, noteY = 2 },
                new Note { noteX = 5, noteY = 3 },
                new Note { noteX = 3, noteY = 4 },
                new Note { noteX = 3, noteY = 5 },
                new Note { noteX = 3, noteY = 6 }
            });

            AddChord("Dm", new List<Note> {
                new Note { noteX = -1, noteY = 1 },
                new Note { noteX = 5, noteY = 2 },
                new Note { noteX = 7, noteY = 3 },
                new Note { noteX = 7, noteY = 4 },
                new Note { noteX = 6, noteY = 5 },
                new Note { noteX = 5, noteY = 6 }
            });
        }
    }
}
