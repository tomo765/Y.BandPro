using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoUI : MonoBehaviour
{
    private GameInfoPresenter m_GameInfoPreseneter;

    [SerializeField] private TMPro.TextMeshProUGUI m_TargetRankText;
    [SerializeField] private TMPro.TextMeshProUGUI m_HaveMoneyText;
    [SerializeField] private Slider m_TimerSlider;

    public TMPro.TextMeshProUGUI TargetRankText => m_TargetRankText;
    public TMPro.TextMeshProUGUI HaveMoneyText => m_HaveMoneyText;
    public Slider TimerSlider => m_TimerSlider;

    private void Awake()
    {
        m_GameInfoPreseneter = new GameInfoPresenter(this);
    }

    void Start()
    {
        m_GameInfoPreseneter.Start();
    }

    void FixedUpdate()
    {
        m_GameInfoPreseneter.FixedUpdate();
    }
}
