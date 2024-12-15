using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ttext = TMPro.TextMeshProUGUI;

public class PerformanceStatusUI : MonoBehaviour
{
    [SerializeField] private Ttext m_Dice1;
    [SerializeField] private Ttext m_Dice2;
    [SerializeField] private Ttext m_Dice3;
    [SerializeField] private Ttext m_Dice4;

    public void UpdateDiceTexts(PerformanceStatus status)
    {
        m_Dice1.text = status.Dice1.ToString();
        m_Dice2.text = status.Dice2.ToString();
        m_Dice3.text = status.Dice3.ToString();
        m_Dice4.text = status.Dice4.ToString();
    }
}
