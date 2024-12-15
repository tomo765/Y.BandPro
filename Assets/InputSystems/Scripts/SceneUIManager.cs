using Nakaya.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUIManager : MonoBehaviour
{
    [SerializeField] private TitleGroup m_TitleGroup;
    [SerializeField] private SettingGroup m_SettingGroup;

    void Start()
    {
        m_TitleGroup.SettingsButton.AddPressAction(() =>
        {
            m_TitleGroup.gameObject.SetActive(false);
            m_SettingGroup.gameObject.SetActive(true);
        });

        m_SettingGroup.ReturnTitleButton.AddPressAction(() =>
        {
            m_SettingGroup.gameObject.SetActive(false);
            m_TitleGroup.gameObject.SetActive(true);
        });
    }
}
