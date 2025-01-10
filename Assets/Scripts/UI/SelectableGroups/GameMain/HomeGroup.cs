using Nakaya.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeGroup : SelectableGroupBase
{
    [SerializeField] private CommonSelectableButton m_RecruiteButton;
    [SerializeField] private CommonSelectableButton m_ActivityButton;
    [SerializeField] private CommonSelectableButton m_PerformanceButton;

    public override ISelectableUI GetInitSelect() => m_RecruiteButton;

    public CommonSelectableButton RecruiteButton => m_RecruiteButton;
    public CommonSelectableButton ActivityButton => m_ActivityButton;
    public CommonSelectableButton PerformanceButton => m_PerformanceButton;


    void Start()
    {
        SetRecruiteButton();
        SetActivityButton();
        SetPerformanceButton();
    }

    private void SetRecruiteButton()
    {
        var recruiteReselect = new ReselectNodeContainer(top: new ReselectNode(m_PerformanceButton), bottom: new ReselectNode(m_ActivityButton));
        m_Selectables.Add(m_RecruiteButton, recruiteReselect);
    }

    private void SetActivityButton()
    {
        var activityReselect = new ReselectNodeContainer(top: new ReselectNode(m_RecruiteButton), bottom: new ReselectNode(m_PerformanceButton));
        m_Selectables.Add(m_ActivityButton, activityReselect);
    }

    private void SetPerformanceButton()
    {
        var performanceReselect = new ReselectNodeContainer(top: new ReselectNode(m_ActivityButton), bottom: new ReselectNode(m_RecruiteButton));
        m_Selectables.Add(m_PerformanceButton, performanceReselect);
    }
}
