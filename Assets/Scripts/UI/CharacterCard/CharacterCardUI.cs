using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ttext = TMPro.TextMeshPro;

public class CharacterCardUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_Rarity;
    [SerializeField] private Ttext m_InstrumentTypeText;
    [SerializeField] private GenreUI m_GenreUI;
    [SerializeField] private SpriteRenderer m_CharaSketch;
    [SerializeField] private InstCardsContainerUI m_Discounts;
    [SerializeField] private PerformanceStatusUI m_PerformanceStatusUI;

    public void UpdateCardInfos(YokaiMember member)  //FixMe : transform.parent を使用しない
    {
        m_InstrumentTypeText.text = member.InstrumentType.ToJapanese();
        m_GenreUI.SetGenreText(member.GenreType?.ToString() ?? string.Empty);
        m_GenreUI.SetActive(!string.IsNullOrEmpty(m_GenreUI.GetGenreText()));
        
        //m_Rarity = new RaritySprite().RareToSprite[member.Rarity];  //FixMe : new の変数をどこからか持ってくる。
        m_Discounts.UpdateText(member.Discount);
    }

    private void Awake()
    {
        SetLayerInChildren(0, transform);

        Debug.Log(m_InstrumentTypeText.GetComponent<Renderer>().sortingOrder);
        Debug.Log(m_Rarity.sortingOrder);
    }

    private void SetLayerInChildren(int layer, params Transform[] objects)
    {
        if(objects.Length == 0) { return; }

        for(int i = 0; i < objects.Length; i++)
        {
            
        }
    }
}

public static class TransformExt
{
    public static Transform[] GetAllChildren(this  Transform parent)
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < parent.childCount; i++) { children.Add(parent.GetChild(i)); }

        return children.ToArray();
    }
}