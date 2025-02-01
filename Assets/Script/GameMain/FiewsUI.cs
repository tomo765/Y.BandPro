using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiewsUI : MonoBehaviour
{
    private class FiewSell
    {
        private Image m_FiewImage;
        private FiewType m_CullentFiew = 0;
        private System.Func<FiewType> ChangeFiew;

        public FiewType CullentFiew => m_CullentFiew;

        public FiewSell(Image fiewImage, System.Func<FiewType> changeFiew)
        {
            m_FiewImage = fiewImage;
            ChangeFiew = changeFiew;
        }

        public void SetNewFiew()
        {
            m_CullentFiew = ChangeFiew();
            m_FiewImage.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[m_CullentFiew];
        }
    }

    [SerializeField] private Image m_FiewSellImage;
                     private FiewSell m_FiewSell;

    [SerializeField] private MyButton m_Fiew1Button;
    [SerializeField] private Image m_Fiew1Image;
                     private FiewPurchase m_FiewPurchase1;

    [SerializeField] private MyButton m_Fiew2Button;
    [SerializeField] private Image m_Fiew2Image;
                     private FiewPurchase m_FiewPurchase2;

    [SerializeField] private MyButton m_Fiew3Button;
    [SerializeField] private Image m_Fiew3Image;
                     private FiewPurchase m_FiewPurchase3;

    public MyButton Fiew1Button => m_Fiew1Button;
    public Image Fiew1Image => m_Fiew1Image;

    public MyButton Fiew2Button => m_Fiew2Button;
    public Image Fiew2Image => m_Fiew2Image;

    public MyButton Fiew3Button => m_Fiew3Button;
    public Image Fiew3Image => m_Fiew3Image;

    void Start()
    {
        m_FiewSell = new FiewSell(m_FiewSellImage, () => 
        {
            FiewType newType;
            while (true)
            {
                Debug.Log(m_FiewSell);
                newType = (FiewType)Random.Range((int)FiewType.Yellow, (int)FiewType.Red);
                if(newType == FiewType.White) { continue; }
                if (m_FiewSell.CullentFiew != newType) { break; }
            }
            return newType;
        });
        m_FiewSell.SetNewFiew();

        m_FiewPurchase1 = new FiewPurchase(m_Fiew1Image);
        m_FiewPurchase2 = new FiewPurchase(m_Fiew2Image);
        m_FiewPurchase3 = new FiewPurchase(m_Fiew3Image);

        m_Fiew1Button.onClick = () =>
        {
            m_FiewPurchase1.SetNewtFiew(m_FiewSell.CullentFiew);
            m_FiewSell.SetNewFiew();
        };
        m_Fiew2Button.onClick = () =>
        {
            m_FiewPurchase2.SetNewtFiew(m_FiewSell.CullentFiew);
            m_FiewSell.SetNewFiew();
        };
        m_Fiew3Button.onClick = () =>
        {
            m_FiewPurchase3.SetNewtFiew(m_FiewSell.CullentFiew);
            m_FiewSell.SetNewFiew();
        };
    }
}
