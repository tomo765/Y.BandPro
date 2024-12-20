using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterControllerUI : MonoBehaviour
{
    private int m_PlayerIndex;
    [SerializeField] private TMPro.TextMeshProUGUI m_IndexText;
    [SerializeField] private Image m_ControllerIllust;

    private TMPro.TextMeshProUGUI IndexText => m_IndexText;
    public int PlayerIndex
    {
        get => m_PlayerIndex;
        private set
        {
            m_PlayerIndex = value;

            if (m_IndexText == null) { return; }
            IndexText.text = value.ToString();
        }
    }


    public void SetActive(bool b) => gameObject.SetActive(b);
    public bool ActiveSelf => gameObject.activeSelf;

    void Start()
    {
        m_IndexText.text = m_PlayerIndex.ToString();
    }

    public void Init(bool isDisplay = true, int index = 0)
    {
        if (!isDisplay) { return; }
        PlayerIndex = index;
        m_ControllerIllust.color = Color.black;
    }

    public void OnControllerRegistered()
    {
        m_ControllerIllust.color = Color.green;
    }

    public void OnControllerUnregistered()
    {
        m_ControllerIllust.color = Color.black;  //ToDo : 点線のコントローラーの画像を差し込む
    }
}
