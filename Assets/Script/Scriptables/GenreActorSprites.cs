using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GenreActorsSprites", menuName = "Scriptables/GenreActorsSprites")]
public class GenreActorSprites : ScriptableObject
{
    [SerializeField] private Sprite m_YellowImage;
    [SerializeField] private Sprite m_RedImage;
    [SerializeField] private Sprite m_MagentaImage;
    [SerializeField] private Sprite m_BlueImage;
    [SerializeField] private Sprite m_CyanImage;
    [SerializeField] private Sprite m_GreenImage;

    public Sprite GetActorSprite(ColorType type)
    {
        return type switch
        {
            ColorType.Yellow => m_YellowImage,
            ColorType.Red => m_RedImage,
            ColorType.Magenta => m_MagentaImage,
            ColorType.Blue => m_BlueImage,
            ColorType.Cyan => m_CyanImage,
            ColorType.Green => m_GreenImage,
            _ => null
        };
    }
}
