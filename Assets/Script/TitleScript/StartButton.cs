using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject startPanel;

    // StartPanelを表示
    public void DispStartPanel()
    {
        startPanel.SetActive(true);
    }
}
