using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiewsUI : MonoBehaviour
{
    private FiewsPresenter m_FiewsPresenter;

    [SerializeField] private MyButton m_ChangeFierw;

    [SerializeField] private Image m_FiewSellImage;

    [SerializeField, Space(10)] private MyButton m_Fiew1Button;
    [SerializeField] private MyButton m_Fiew1DeleteButton;
    [SerializeField] private Image m_Fiew1Image;

    [SerializeField, Space(10)] private MyButton m_Fiew2Button;
    [SerializeField] private MyButton m_Fiew2DeleteButton;
    [SerializeField] private Image m_Fiew2Image;

    [SerializeField, Space(10)] private MyButton m_Fiew3Button;
    [SerializeField] private MyButton m_Fiew3DeleteButton;
    [SerializeField] private Image m_Fiew3Image;

    public MyButton ChangeFierw => m_ChangeFierw;
    public Image FiewSellImage => m_FiewSellImage;

    public MyButton Fiew1Button => m_Fiew1Button;
    public MyButton Fiew1DeleteButton => m_Fiew1DeleteButton;
    public Image Fiew1Image => m_Fiew1Image;

    public MyButton Fiew2Button => m_Fiew2Button;
    public MyButton Fiew2DeleteButton => m_Fiew2DeleteButton;
    public Image Fiew2Image => m_Fiew2Image;

    public MyButton Fiew3Button => m_Fiew3Button;
    public MyButton Fiew3DeleteButton => m_Fiew3DeleteButton;
    public Image Fiew3Image => m_Fiew3Image;

    void Start()
    {
        GameDataManager.Instance.InitFiewsModel(new FiewPurchase(m_Fiew1Image, 1),
                                                new FiewPurchase(m_Fiew2Image, 2),
                                                new FiewPurchase(m_Fiew3Image, 3));

        m_FiewsPresenter = new FiewsPresenter(this);
        m_FiewsPresenter.Start();
    }
}
