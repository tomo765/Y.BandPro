using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : UIBase
{
    [SerializeField] private MyButton m_StartButton;

    public MyButton StartButton => m_StartButton;
}
