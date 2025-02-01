using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreClipManager : MonoBehaviour
{
    
    [SerializeField] private GenreClips m_YellowClips;
    [SerializeField] private GenreClips m_MagentaClips;
    [SerializeField] private GenreClips m_CyanClips;
    [SerializeField] private GenreClips m_RedClips;
    [SerializeField] private GenreClips m_GreenClips;
    [SerializeField] private GenreClips m_BlueClips;

    public GenreClips GetGenreClips(GenreType type)
    {
        return type switch
        {
            GenreType.Yellow => m_YellowClips,
            GenreType.Magenta => m_MagentaClips,
            GenreType.Cyan => m_CyanClips,
            GenreType.Red => m_RedClips,
            GenreType.Green => m_GreenClips,
            GenreType.Blue => m_BlueClips,
            _ => null
        };
    }
}

public enum GenreType
{
    Yellow,
    Magenta,
    Cyan,
    Red,
    Green,
    Blue
}