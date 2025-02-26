using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TText = TMPro.TextMeshProUGUI;

public class CustomerCountUI : MonoBehaviour
{
    [SerializeField] private TText m_CustomerCountText;
    [SerializeField] private TText m_MaxCustomerCountText;

    public void SetCountText(int count) => m_CustomerCountText.text = count.ToString();
    public void SetMaxCountText(int count) => m_MaxCustomerCountText.text = "/ " + count.ToString();

    private void Start()
    {
        GameDataManager.Instance.CustomersModel.OnAddCustomer += SetCountText;
        GameDataManager.Instance.CustomersModel.OnChangeMaxCustomerCount += SetMaxCountText;

        SetCountText(0);
    }
}