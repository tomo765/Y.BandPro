using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FiewSprites", menuName = "Scriptables/FiewSprites")]
public class FiewSprites : ScriptableObject
{
    [SerializeField] private Sprite m_WhiteFiew;
    [SerializeField] private Sprite m_YellowFiew;
    [SerializeField] private Sprite m_MagentaFiew;
    [SerializeField] private Sprite m_CyanFiew;
    [SerializeField] private Sprite m_RedFiew;
    [SerializeField] private Sprite m_GreenFiew;
    [SerializeField] private Sprite m_BlueFiew;

    public Dictionary<ColorType, Sprite> TypeToSprite => new Dictionary<ColorType, Sprite>
    {
        {ColorType.White, m_WhiteFiew},
        {ColorType.Yellow, m_YellowFiew},
        {ColorType.Magenta, m_MagentaFiew},
        {ColorType.Cyan, m_CyanFiew},
        {ColorType.Red, m_RedFiew},
        {ColorType.Green, m_GreenFiew},
        {ColorType.Blue, m_BlueFiew},
    };
}
