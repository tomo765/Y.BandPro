using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ttext = TMPro.TextMeshProUGUI;

[RequireComponent(typeof(Image))]
public class InstrumentCard : MonoBehaviour
{
    [SerializeField] private Ttext m_Ttext;
    [SerializeField] private Image m_Image;
    [SerializeField] private GameObject m_Parent;
    private InstrumentType m_Type;


    public InstrumentType Type => m_Type;
    public GameObject ParentObject => m_Parent;

    public void SetText(int statusInt) { m_Ttext.text = statusInt.ToString(); }

    public void Init(int statusInt, InstrumentType type)
    {
        m_Ttext.text = statusInt.ToString();
        m_Type = type;
        //GetComponent<Image>().sprite = new InstrumentSprite().TypeToSprite[type];  //FixMe : new の変数をどこからか持ってくる。
    }
}
