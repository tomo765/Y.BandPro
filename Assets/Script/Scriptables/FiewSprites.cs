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

    public Dictionary<FiewType, Sprite> TypeToSprite => new Dictionary<FiewType, Sprite>
    {
        {FiewType.White, m_WhiteFiew},
        {FiewType.Yellow, m_YellowFiew},
        {FiewType.Magenta, m_MagentaFiew},
        {FiewType.Cyan, m_CyanFiew},
        {FiewType.Red, m_RedFiew},
        {FiewType.Green, m_GreenFiew},
        {FiewType.Blue, m_BlueFiew},
    };
}
