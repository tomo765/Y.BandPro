using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGaugeModel
{
    private float m_RedGauge = 0;
    private float m_GreenGauge = 0;
    private float m_BlueGauge = 0;

    public float RedGauge => m_RedGauge;
    public float GreenGauge => m_GreenGauge;
    public float BlueGauge => m_BlueGauge;

    public bool IsFullRedGauge => m_RedGauge >= 1.0f;
    public bool IsFullGreenGauge => m_GreenGauge >= 1.0f;
    public bool IsFullBlueGauge => m_BlueGauge >= 1.0f;

    public void AddRedGauge(float value) => m_RedGauge = Mathf.Clamp01(m_RedGauge + value);
    public void ResetRedGauge() => m_RedGauge = 0;

    public void AddGreenGauge(float value) => m_GreenGauge = Mathf.Clamp01(m_GreenGauge + value);
    public void ResetGreenGauge() => m_GreenGauge = 0;
    public void AddBlueGauge(float value) => m_BlueGauge = Mathf.Clamp01(m_BlueGauge + value);
    public void ResetBlueGauge() => m_BlueGauge = 0;
}
