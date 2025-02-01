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

    public ColorType GetTypeWithTwo(ColorType type1, ColorType type2)
    {
        if (type2 == ColorType.White) { return type1; }
        if (type1 == type2) { return type1; }

        if (type1 == ColorType.Yellow)
        {
            if (type2 == ColorType.Magenta) { return ColorType.Red; }
            else/*(type2 == FiewType.Cyan)*/ { return ColorType.Green; }
        }
        else if (type1 == ColorType.Magenta)
        {
            if (type2 == ColorType.Yellow) { return ColorType.Red; }
            else/*(type2 == FiewType.Cyan)*/ { return ColorType.Blue; }
        }
        else/*(type1 == FiewType.Cyan)*/
        {
            if (type2 == ColorType.Yellow) { return ColorType.Green; }
            else/*(type2 == FiewType.Magenta)*/ { return ColorType.Blue; }
        }
    }

    public FiewSprites FiewSprites => m_FiewSprites;
}