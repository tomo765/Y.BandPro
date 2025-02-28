using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ttext = TMPro.TextMeshProUGUI;

public class ExpansionUI : MonoBehaviour
{
    private ExpansionPresenter m_ExpansionPresenter;

    [SerializeField] private MyButton m_ExpandStoreButton;
    [SerializeField] private Ttext m_ExpandStoreCount;
    [SerializeField] private Ttext m_ExpandStoreMoney;

    [SerializeField, Space(10)] private MyButton m_DrinkServiceButton;
    [SerializeField] private Ttext m_DrinkServiceCount;
    [SerializeField] private Ttext m_DrinkServiceMoney;

    [SerializeField, Space(10)] private MyButton m_UpgradeEquipmentButton;
    [SerializeField] private Ttext m_UpgradeEquipmentCount;
    [SerializeField] private Ttext m_UpgradeEquipmentMoney;

    public MyButton ExpandStoreButton => m_ExpandStoreButton;
    public Ttext ExpandStoreCount => m_ExpandStoreCount;
    public Ttext ExpandStoreMoney => m_ExpandStoreMoney;

    public MyButton DrinkServiceButton => m_DrinkServiceButton;
    public Ttext DrinkServiceCount => m_DrinkServiceCount;
    public Ttext DrinkServiceMoney => m_DrinkServiceMoney;

    public MyButton UpgradeEquipmentButton => m_UpgradeEquipmentButton;
    public Ttext UpgradeEquipmentCount => m_UpgradeEquipmentCount;
    public Ttext UpgradeEquipmentMoney => m_UpgradeEquipmentMoney;



    void Start()
    {
        GameDataManager.Instance.InitExpansionModel();
        m_ExpansionPresenter = new ExpansionPresenter(this);
        m_ExpansionPresenter.Start();
    }
}
