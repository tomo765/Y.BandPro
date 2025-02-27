using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionModel
{
    public const int MaxExpandStore = 5;
    public const int MaxDrinkService = 3;
    public const int MaxUpgradeEquipment = 3;

    private int m_ExpandStoreCount = 0;
    private int m_DrinkServiceCount = 0;
    private int m_UpgradeEquipmentCount = 0;

    public int ExpandStoreCount => m_ExpandStoreCount;
    public int RemainingExpandStore => MaxExpandStore - m_ExpandStoreCount;
    public bool CanExpandStore => m_ExpandStoreCount < MaxExpandStore;
    public void AddExpandStoreCount() => m_ExpandStoreCount++;

    public int RemainingDrinkService => MaxDrinkService - m_DrinkServiceCount;
    public bool CanDrinkService => m_DrinkServiceCount < MaxDrinkService;
    public void AddDrinkServiceCount() => m_DrinkServiceCount++;
    
    public int RemainingUpgradeEquipment => MaxUpgradeEquipment - m_UpgradeEquipmentCount;
    public bool CanUpgradeEquipment => m_UpgradeEquipmentCount < MaxUpgradeEquipment;
    public void AddUpgradeEquipmentCount() => m_UpgradeEquipmentCount++;
}
