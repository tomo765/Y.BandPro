using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptablesManager : SingletonBehaviour<ScriptablesManager>
{    
    [SerializeField] private GenreClips m_YellowClips;
    [SerializeField] private GenreClips m_MagentaClips;
    [SerializeField] private GenreClips m_CyanClips;
    [SerializeField] private GenreClips m_RedClips;
    [SerializeField] private GenreClips m_GreenClips;
    [SerializeField] private GenreClips m_BlueClips;

    [SerializeField] private FiewSprites m_FiewSprites;

    public GenreClips GetGenreClips(ColorType type)
    {
        return type switch
        {
            ColorType.Yellow => m_YellowClips,
            ColorType.Magenta => m_MagentaClips,
            ColorType.Cyan => m_CyanClips,
            ColorType.Red => m_RedClips,
            ColorType.Green => m_GreenClips,
            ColorType.Blue => m_BlueClips,
            _ => null
        };
    }

    public FiewSprites FiewSprites => m_FiewSprites;
}