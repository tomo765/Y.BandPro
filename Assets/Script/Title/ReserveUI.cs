using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveUI : UIBase
{
    [SerializeField] private MyButton m_PlayButton;
    [SerializeField] private MyButton m_BackButton;

    public MyButton PlayButton => m_PlayButton;
    public MyButton BackButton => m_BackButton;
}
