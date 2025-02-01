using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JenreClips", menuName = "Scriptables/JenreClips")]
public class GenreClips : ScriptableObject
{
    [SerializeField] private ColorType m_FiewType;

    [SerializeField] private AudioClip m_Music1;
    [SerializeField] private AudioClip m_Music2;
    [SerializeField] private AudioClip m_Music3;
    [SerializeField, Range(0, 1f)] private float m_Volume = 1f;

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

    public ColorType FiewType => m_FiewType;
    public float Volume => m_Volume;
}

public enum MusicType
{
    Main,
    Mus1,
    Mus2,
    Mus3
}