using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptablesManager : SingletonBehaviour<ScriptablesManager>
{
    [SerializeField] private GenreClips m_MainClips;
    [SerializeField] private GenreClips m_YellowClips;
    [SerializeField] private GenreClips m_MagentaClips;
    [SerializeField] private GenreClips m_CyanClips;
    [SerializeField] private GenreClips m_RedClips;
    [SerializeField] private GenreClips m_GreenClips;
    [SerializeField] private GenreClips m_BlueClips;

    [SerializeField] private FiewSprites m_FiewSprites;
    [SerializeField] private GenreActorSprites m_ActorSprites;

    public GenreClips MainClips => m_MainClips;

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

            ColorType.White_Yellow => m_YellowClips,
            ColorType.White_Magenta => m_MagentaClips,
            ColorType.White_Cyan => m_CyanClips,
            _ => null
        };
    }

    public FiewSprites FiewSprites => m_FiewSprites;
    public GenreActorSprites ActorSprites => m_ActorSprites;
}