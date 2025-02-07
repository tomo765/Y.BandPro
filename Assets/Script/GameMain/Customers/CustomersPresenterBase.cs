using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CustomersPresenterBase
{
    protected CustomerUI m_CustomerUI;
    public CustomersPresenterBase(CustomerUI customerUI)
    {
        m_CustomerUI = customerUI;
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

    private List<CustomerModel> m_Customers = new List<CustomerModel>();
    private int m_MaxCustomerCount;

    public List<ColorType> AllCustomerColor => m_Customers.Select(c => c.ColorType).ToList();
    public int CustomerCount => m_Customers.Count;
    public int MaxCustomerCount => m_MaxCustomerCount;

    public CustomersModel(int maxCustomerCount)
    {
        m_MaxCustomerCount = maxCustomerCount;
    }

    public void AddCustomer(CustomerModel customer) => m_Customers.Add(customer);
    public ColorType GetRandomColorType() => CustomerColors[Random.Range(0, CustomerColors.Length)];
}