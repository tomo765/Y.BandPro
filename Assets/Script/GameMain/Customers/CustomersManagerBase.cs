using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CustomersManagerBase
{

    public CustomersManagerBase()
    {
        GameDataManager.Instance.InitCustomersModel(30);
    }

    protected abstract void AddCustomer();

    public virtual void Awake() { }
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}

public class CustomersModel
{
    public readonly ColorType[] CustomerColors = { ColorType.Red, ColorType.Green, ColorType.Blue };

    private List<Customer> m_Customers = new List<Customer>();
    private int m_MaxCustomerCount;

    public int CustomerCount => m_Customers.Count;
    public int MaxCustomerCount => m_MaxCustomerCount;

    public CustomersModel(int maxCustomerCount)
    {
        m_MaxCustomerCount = maxCustomerCount;
    }

    public void AddCustomer(Customer customer) => m_Customers.Add(customer);
    public ColorType GetRandomColorType() => CustomerColors[Random.Range(0, CustomerColors.Length)];
}