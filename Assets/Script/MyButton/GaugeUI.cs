using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeUI : MonoBehaviour
{
    [SerializeField] private Image m_GaugeImage;
    private float m_FillValue;

    public void UpdateGaugeFill(float value)
    {
        m_FillValue = Mathf.Clamp01(value);
        m_GaugeImage.fillAmount = m_FillValue;
    }

    public void OnFullGauge()
    {
        m_FillValue = 0;
        m_GaugeImage.fillAmount = m_FillValue;
    }
}
