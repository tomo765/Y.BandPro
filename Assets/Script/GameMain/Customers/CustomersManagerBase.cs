using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CustomersManagerBase
{
    protected readonly ColorType[] CustomerColors = { ColorType.Red, ColorType.Green, ColorType.Blue };

    protected List<Customer> m_Customers = new List<Customer>();
    protected int m_MaxCustomerCount = 30;

    public int CustomerCount => m_Customers.Count;
    public int MaxCustomerCount => m_MaxCustomerCount;

    protected abstract void AddCustomer();

    public virtual void Awake() { }
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}