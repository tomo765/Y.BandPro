using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCountPresenter
{
    private CustomerCountUI m_CustomerCountUI;

    private CustomerCountPresenter() { }
    public CustomerCountPresenter(CustomerCountUI customerCountUI)
    {
        m_CustomerCountUI = customerCountUI;
    }
}
