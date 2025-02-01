using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptablesManager : SingletonBehaviour<ScriptablesManager>
{
    private readonly LinkedList<ColorType> ColorTransitionChain 
        = new LinkedList<ColorType>(new List<ColorType>
            { 
                ColorType.Yellow,
                ColorType.Red,
                ColorType.Magenta,
                ColorType.Blue,
                ColorType.Cyan,
                ColorType.Green,
            });
    
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

    public ColorType GetMixedColor(ColorType type1, ColorType type2)
    {
        if(type2 == ColorType.White) { return type1; }
        if(type1 == type2) { return type1; }

        int[] values = new int[] { GetColorIndex(type1), GetColorIndex(type2) };

        //Yellow ‚Æ Cyan ‚¾‚Á‚½Žž‚É Green ‚ð•Ô‚·
        if (values[0] == 0 && values[1] == 4 || values[0] == 4 && values[1] == 0) 
            { return ColorTransitionChain.ElementAt(5); }
        
        return ColorTransitionChain.ElementAt((values[0]+ values[1])/2);

        int GetColorIndex(ColorType type)
        {
            int i = 0;
            for (; i < ColorTransitionChain.Count; i++)
            {
                if (ColorTransitionChain.ElementAt(i) == type) { break; }
            }
            return i;
        }
    }

    public FiewSprites FiewSprites => m_FiewSprites;
}