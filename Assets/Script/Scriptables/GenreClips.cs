using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JenreClips", menuName = "Scriptables/JenreClips")]
public class GenreClips : ScriptableObject
{
    [SerializeField] private AudioClip m_Music1;
    [SerializeField] private AudioClip m_Music2;
    [SerializeField] private AudioClip m_Music3;

    public AudioClip GetAudioClipAsType(MusicType type)
    {
        return type switch
        {
            MusicType.Mus1 => m_Music1,
            MusicType.Mus2 => m_Music2,
            MusicType.Mus3 => m_Music3,
            _ => null
        };
    }
}

public enum MusicType
{
    Mus1,
    Mus2,
    Mus3
}