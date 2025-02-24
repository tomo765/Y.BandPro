using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerModel
{
    private const float PayMoneyTime = 10f;
    
    private CustomerObject m_CustomerObject;
    private float m_CullentTime = 0;

    public ColorType ColorType => m_CustomerObject.ColorType;

    public bool PayableMoney => m_CullentTime >= PayMoneyTime;

    public CustomerModel(CustomerObject customerObject)
    {
        m_CustomerObject = customerObject;
    }

    public void Start()
    {
        
    }


    public void Update()
    {
        
    }

    public void UpdatePay(float time)
    {
        m_CullentTime += time;
        if(m_CullentTime < PayMoneyTime) { return; }

        m_CullentTime = 0;
        GameDataManager.Instance.GameInfoModel.AddMoney(100);
    }
}
