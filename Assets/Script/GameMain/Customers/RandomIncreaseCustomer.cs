using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIncreaseCustomer : CustomersManagerBase
{
    private float m_DefaultIncreaseTime = 15f;
    private float m_CullentElapseTime = 0;
    private float m_IncreaseMultiplier = 1;

    private ColorType GetRandomColorType() 
        => CustomerColors[Random.Range(0, CustomerColors.Length)];

    private void AddTime()
    {
        m_CullentElapseTime += Time.deltaTime * m_IncreaseMultiplier;
    }

    protected override void AddCustomer()
    {
        if(m_Customers.Count >= m_MaxCustomerCount) { return; }
        m_Customers.Add(new Customer(GetRandomColorType()));
    }


    public override void Start()
    {
        
    }

    public override void Update()
    {
        AddTime();
        if (m_CullentElapseTime >= m_DefaultIncreaseTime)
        {
            AddCustomer();
            m_CullentElapseTime -= m_DefaultIncreaseTime;
        }
    }
}
