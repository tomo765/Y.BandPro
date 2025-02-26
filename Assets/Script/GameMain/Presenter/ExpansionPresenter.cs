using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionPresenter
{
    private ExpansionUI m_ExpansionUI;

    private ExpansionPresenter() { }

    public ExpansionPresenter(ExpansionUI expansionUI)
    {
        m_ExpansionUI = expansionUI;
    }

    public void Start()
    {
        SetExpandStoreButton();
        SetDrinkServiceButton();
        SetUpgradeEquipmentButton();
    }

    private void SetExpandStoreButton()
    {
        m_ExpansionUI.ExpandStoreCount.text = GetCountText(GameDataManager.Instance.ExpansionModel.RemainingExpandStore, ExpansionModel.MaxExpandStore);
        m_ExpansionUI.ExpandStoreButton.onClick += () =>
        {
            if (!GameDataManager.Instance.ExpansionModel.CanExpandStore) { return; }
            GameDataManager.Instance.CustomersModel.UpdateMaxCustomerCount(GameDataManager.Instance.CustomersModel.MaxCustomerCount + 10);
            GameDataManager.Instance.GameInfoModel.TryUseMoney(1000);

            GameDataManager.Instance.ExpansionModel.AddExpandStoreCount();
            m_ExpansionUI.ExpandStoreCount.text = GetCountText(GameDataManager.Instance.ExpansionModel.RemainingExpandStore, ExpansionModel.MaxExpandStore);
            m_ExpansionUI.ExpandStoreButton.SetEnabled(GameDataManager.Instance.ExpansionModel.CanExpandStore);
        };
    }

    private void SetDrinkServiceButton()
    {
        m_ExpansionUI.DrinkServiceCount.text = GetCountText(GameDataManager.Instance.ExpansionModel.RemainingDrinkService, ExpansionModel.MaxDrinkService);
        m_ExpansionUI.DrinkServiceButton.onClick += () =>
        {
            if (!GameDataManager.Instance.ExpansionModel.CanDrinkService) { return; }
            GameDataManager.Instance.GameInfoModel.TryUseMoney(1000);

            GameDataManager.Instance.ExpansionModel.AddDrinkServiceCount();
            m_ExpansionUI.DrinkServiceCount.text = GetCountText(GameDataManager.Instance.ExpansionModel.RemainingDrinkService, ExpansionModel.MaxDrinkService);
            m_ExpansionUI.DrinkServiceButton.SetEnabled(GameDataManager.Instance.ExpansionModel.CanDrinkService);
        };
    }

    private void SetUpgradeEquipmentButton()
    {
        m_ExpansionUI.UpgradeEquipmentCount.text = GetCountText(GameDataManager.Instance.ExpansionModel.RemainingUpgradeEquipment, ExpansionModel.MaxUpgradeEquipment);
        m_ExpansionUI.UpgradeEquipmentButton.onClick += () =>
        {
            if (!GameDataManager.Instance.ExpansionModel.CanUpgradeEquipment) { return; }
            GameDataManager.Instance.GameInfoModel.TryUseMoney(1000);

            GameDataManager.Instance.ExpansionModel.AddUpgradeEquipmentCount();
            m_ExpansionUI.UpgradeEquipmentCount.text = GetCountText(GameDataManager.Instance.ExpansionModel.RemainingUpgradeEquipment, ExpansionModel.MaxUpgradeEquipment);
            m_ExpansionUI.UpgradeEquipmentButton.SetEnabled(GameDataManager.Instance.ExpansionModel.CanUpgradeEquipment);
        };
    }

    private string GetCountText(int count, int max) => count.ToString() + " / " + max.ToString();
}
