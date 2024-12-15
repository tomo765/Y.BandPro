using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InstrumentSprite", menuName = "Scriptables/Create InstrumentSprite")]
public class InstrumentSprite : ScriptableObject
{
#if UNITY_EDITOR
    [SpritePreview]
# endif
    [SerializeField] private Sprite m_WindSprite;

#if UNITY_EDITOR
    [SpritePreview]
#endif
    [SerializeField] private Sprite m_PercussionSprite;

#if UNITY_EDITOR
    [SpritePreview]
#endif
    [SerializeField] private Sprite m_StringsSprite;

#if UNITY_EDITOR
    [SpritePreview]
#endif
    [SerializeField] private Sprite m_KeyboardSprite;

#if UNITY_EDITOR
    [SpritePreview]
#endif
    [SerializeField] private Sprite m_GoldSprite;

    public Dictionary<InstrumentType, Sprite> TypeToSprite =>
        new Dictionary<InstrumentType, Sprite>
        {
            {InstrumentType.Wind, m_WindSprite},
            {InstrumentType.Percussion, m_PercussionSprite},
            {InstrumentType.Strings, m_StringsSprite},
            {InstrumentType.Keyboard, m_KeyboardSprite},
            {InstrumentType.Wind, m_WindSprite},
            {InstrumentType.Gold, m_GoldSprite},
        };

    private InstrumentSprite() { }
}
