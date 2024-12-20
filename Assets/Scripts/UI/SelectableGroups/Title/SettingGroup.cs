using Nakaya.UI;
using UnityEngine;

public class SettingGroup : SelectableGroupBase
{
    [SerializeField] private CommonSelectableButton m_ReturnTitleButton;
    [SerializeField] private CommonSelectableButton m_ExitButton;

    public CommonSelectableButton ReturnTitleButton => m_ReturnTitleButton;
    public CommonSelectableButton ExitButton => m_ExitButton;

    public override ISelectableUI GetInitSelect() => m_ReturnTitleButton;


    void Start()
    {
        SetTitleButton();
        SetExitButton();

        UnselectFireActions = new UnselectFireAction(onCancel: () => m_ReturnTitleButton.Press());
    }

    private void SetTitleButton()
    {
        m_ReturnTitleButton.AddPressAction(() =>
        {
            Debug.Log("Return to Title");
        });

        var ReturnTitleReselect = new ReselectNodeContainer(top: new ReselectNode(m_ExitButton), bottom: new ReselectNode(m_ExitButton));
        m_Selectables.Add(m_ReturnTitleButton, ReturnTitleReselect);
    }

    private void SetExitButton()
    {
        m_ExitButton.AddPressAction(() =>
        {
            Debug.Log("Exit");
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
        });

        var ExitReselect = new ReselectNodeContainer(top: new ReselectNode(m_ReturnTitleButton), bottom: new ReselectNode(m_ReturnTitleButton));
        m_Selectables.Add(m_ExitButton, ExitReselect);
    }


    void Update()
    {
        
    }
}
