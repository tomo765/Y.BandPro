using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private ScorePresenter m_ScorePresenter;

    [SerializeField] private FiewsUI m_FiewsUI;

    [SerializeField] private TMPro.TextMeshProUGUI m_RankText;
    [SerializeField] private TMPro.TextMeshProUGUI m_ScoreText;

    public FiewsUI FiewsUI => m_FiewsUI;

    public TMPro.TextMeshProUGUI RankText => m_RankText;
    public TMPro.TextMeshProUGUI ScoreText => m_ScoreText;

    void Start()
    {
        m_ScorePresenter = new ScorePresenter(this);
    }


    void FixedUpdate()
    {
        m_ScorePresenter.FixedUpdate();
    }
}
