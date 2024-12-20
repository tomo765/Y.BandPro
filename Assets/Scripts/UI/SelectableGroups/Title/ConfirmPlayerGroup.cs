using Nakaya.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConfirmPlayerGroup : SelectableGroupBase
{
    [SerializeField] private CommonSelectableButton m_OKButton;
    [SerializeField] private CommonSelectableButton m_NoButton;

    public CommonSelectableButton OKButton => m_OKButton;
    public CommonSelectableButton NoButton => m_NoButton;

    public override ISelectableUI GetInitSelect() => m_OKButton;


    void Start()
    {
        SetOKButton();
        SetNoButton();

        UnselectFireActions = new UnselectFireAction(onCancel: () => m_NoButton.Press());
    }

    private void SetOKButton()
    {
        m_OKButton.AddPressAction(() =>
        {
            Debug.Log("OK");
        });

        var OKReselect = new ReselectNodeContainer(left : new(m_NoButton));
        m_Selectables.Add(m_OKButton, OKReselect);
    }

    private void SetNoButton()
    {
        m_NoButton.AddPressAction(() =>
        {
            Debug.Log("No");
        });

        var NoReselect = new ReselectNodeContainer(right : new(m_OKButton));
        m_Selectables.Add(m_NoButton, NoReselect);
    }
}
