using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGaugeModel
{
    private float m_YellowGauge = 0;
    private float m_MagentaGauge = 0;
    private float m_CyanGauge = 0;

    public float YellowGauge => m_YellowGauge;
    public float MagentaGauge => m_MagentaGauge;
    public float CyanGauge => m_CyanGauge;

    public void AddYellowGauge(float value) => m_YellowGauge += value;
    public void AddMagentaGauge(float value) => m_MagentaGauge += value;
    public void AddCyanGauge(float value) => m_CyanGauge += value;
}
