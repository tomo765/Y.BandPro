using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerModel
{
    private CustomerObject m_CustomerObject;

    public ColorType ColorType => m_CustomerObject.ColorType;

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
}
