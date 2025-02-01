using System.Collections;
using System.Collections.Generic;
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

    public GenreClips GetGenreClips(FiewType type)
    {
        return type switch
        {
            FiewType.Yellow => m_YellowClips,
            FiewType.Magenta => m_MagentaClips,
            FiewType.Cyan => m_CyanClips,
            FiewType.Red => m_RedClips,
            FiewType.Green => m_GreenClips,
            FiewType.Blue => m_BlueClips,
            _ => null
        };
    }

    public FiewType GetTypeWithTwo(FiewType type1, FiewType type2)
    {
        if (type2 == FiewType.White) { return type1; }
        if (type1 == type2) { return type1; }

        if (type1 == FiewType.Yellow)
        {
            if (type2 == FiewType.Magenta) { return FiewType.Red; }
            else/*(type2 == FiewType.Cyan)*/ { return FiewType.Green; }
        }
        else if (type1 == FiewType.Magenta)
        {
            if (type2 == FiewType.Yellow) { return FiewType.Red; }
            else/*(type2 == FiewType.Cyan)*/ { return FiewType.Blue; }
        }
        else/*(type1 == FiewType.Cyan)*/
        {
            if (type2 == FiewType.Yellow) { return FiewType.Green; }
            else/*(type2 == FiewType.Magenta)*/ { return FiewType.Blue; }
        }
    }

    public FiewSprites FiewSprites => m_FiewSprites;
}