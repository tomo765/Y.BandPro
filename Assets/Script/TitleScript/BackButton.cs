using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject startPanel;

    // StartPanelを非表示にする
    public void BackToStart ()
    {
        startPanel.SetActive(false);
    }
}
