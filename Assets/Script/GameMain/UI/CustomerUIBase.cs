using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerUIBase : MonoBehaviour
{
    [SerializeField] private CustomerObject m_RedCustomer;
    [SerializeField] private CustomerObject m_GreenCustomer;
    [SerializeField] private CustomerObject m_BlueCustomer;

    public CustomerObject RedCustomer => m_RedCustomer;
    public CustomerObject GreenCustomer => m_GreenCustomer;
    public CustomerObject BlueCustomer => m_BlueCustomer;
}
