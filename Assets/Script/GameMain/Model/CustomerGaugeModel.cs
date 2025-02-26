using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGaugeModel
{
    private float m_RedGauge = 0;
    private float m_GreenGauge = 0;
    private float m_BlueGauge = 0;


    public float GetGauge(ColorType type)
    {
        return (type) switch
        {
            ColorType.Red => m_RedGauge,
            ColorType.Green => m_GreenGauge,
            ColorType.Blue => m_BlueGauge,
            _ => 0,
        };
    }
    public bool GetIsFullGauge(ColorType type)
    {
        return (type) switch
        {
            ColorType.Red => m_RedGauge >= 1.0f,
            ColorType.Green => m_GreenGauge >= 1.0f,
            ColorType.Blue => m_BlueGauge >= 1.0f,
            _ => false,
        };
    }
    public void UpdateGauge(ColorType type, float value)
    {
        switch (type)
        {
            case ColorType.Red:
                m_RedGauge = Mathf.Clamp01(value);
                break;
            case ColorType.Green:
                m_GreenGauge = Mathf.Clamp01(value);
                break;
            case ColorType.Blue:
                m_BlueGauge = Mathf.Clamp01(value);
                break;
        }
    }
    public void ResetGauge(ColorType type)
    {
        switch (type)
        {
            case ColorType.Red:
                m_RedGauge = 0;
                break;
            case ColorType.Green:
                m_GreenGauge = 0;
                break;
            case ColorType.Blue:
                m_BlueGauge = 0;
                break;
        }
    }
}