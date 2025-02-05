using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiewsUI : MonoBehaviour
{
    private FiewsPresenter m_FiewsPresenter;

    [SerializeField] private MyButton m_ChangeFierw;

    [SerializeField,SpaceAttribute(5)] private Image m_FiewSellImage;

    [SerializeField] private MyButton m_Fiew1Button;
    [SerializeField] private Image m_Fiew1Image;

    [SerializeField] private MyButton m_Fiew2Button;
    [SerializeField] private Image m_Fiew2Image;

    [SerializeField] private MyButton m_Fiew3Button;
    [SerializeField] private Image m_Fiew3Image;

    public MyButton ChangeFierw => m_ChangeFierw;
    public Image FiewSellImage => m_FiewSellImage;
    public MyButton Fiew1Button => m_Fiew1Button;
    public Image Fiew1Image => m_Fiew1Image;

    public MyButton Fiew2Button => m_Fiew2Button;
    public Image Fiew2Image => m_Fiew2Image;

    public MyButton Fiew3Button => m_Fiew3Button;
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
