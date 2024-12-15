using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstCardsContainerUI : MonoBehaviour
{
    [SerializeField] private InstrumentCard m_WindCard;
    [SerializeField] private InstrumentCard m_StringsCard;
    [SerializeField] private InstrumentCard m_PercussionCard;
    [SerializeField] private InstrumentCard m_KeyboardCard;

    public void UpdateText(Instruments cost)
    {
        m_WindCard.SetText(cost.Wind);
        m_WindCard.ParentObject.SetActive(cost.Wind != 0);

        m_PercussionCard.SetText(cost.Percussion);
        m_PercussionCard.ParentObject.SetActive(cost.Percussion != 0);

        m_StringsCard.SetText(cost.Strings);
        m_StringsCard.ParentObject.SetActive(cost.Strings != 0);

        m_KeyboardCard.SetText(cost.Keyboard);
        m_KeyboardCard.ParentObject.SetActive(cost.Keyboard != 0);
    }
}
