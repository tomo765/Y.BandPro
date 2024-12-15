using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RaritySprite", menuName = "Scriptables/Create RaritySprite")]
public class RaritySprite : ScriptableObject
{
#if UNITY_EDITOR
    [SpritePreview]
#endif
    [SerializeField] private Sprite m_Rare1;

#if UNITY_EDITOR
    [SpritePreview]
#endif
    [SerializeField] private Sprite m_Rare2;

#if UNITY_EDITOR
    [SpritePreview]
#endif
    [SerializeField] private Sprite m_Rare3;

    public Dictionary<int, Sprite> RareToSprite => new Dictionary<int, Sprite>
    {
        { 1, m_Rare1 }, 
        { 2, m_Rare2 }, 
        { 3, m_Rare3 }
    };


    private RaritySprite() { }
}
