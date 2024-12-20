using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ttext = TMPro.TextMeshProUGUI;

public class CharacterCardUI : MonoBehaviour
{
    [SerializeField] private Image m_Rarity;
    [SerializeField] private Ttext m_InstrumentTypeText;
    [SerializeField] private GenreUI m_GenreUI;
    [SerializeField] private Image m_CharaSketch;
    [SerializeField] private InstCardsContainerUI m_Costs;
    [SerializeField] private InstCardsContainerUI m_Discounts;
    [SerializeField] private PerformanceStatusUI m_PerformanceStatusUI;

    public void UpdateCardInfos(YokaiMember member)  //FixMe : transform.parent を使用しない
    {
        m_InstrumentTypeText.text = member.InstrumentType.ToJapanese();
        m_GenreUI.SetGenreText(member.GenreType?.ToString() ?? string.Empty);
        m_GenreUI.SetActive(!string.IsNullOrEmpty(m_GenreUI.GetGenreText()));

        //m_Rarity = new RaritySprite().RareToSprite[member.Rarity];  //FixMe : new の変数をどこからか持ってくる。
        m_Costs.UpdateText(member.Cost);
        m_Discounts.UpdateText(member.Discount);
    }
}
