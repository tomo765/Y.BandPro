using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CustomersPresenterBase<T> where T : CustomerUIBase
{
    protected T m_CustomerUI;
    public CustomersPresenterBase(T customerUI)
    {
        m_CustomerUI = customerUI;
        GameDataManager.Instance.InitCustomersModel(30);
    }

    protected abstract void AddCustomer(ColorType type);

    public virtual void Awake() { }
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }


    protected CustomerObject GetCustomerObjAsColor(ColorType type)
    {
        return type switch
        {
            ColorType.Red => m_CustomerUI.RedCustomer,
            ColorType.Green => m_CustomerUI.GreenCustomer,
            ColorType.Blue => m_CustomerUI.BlueCustomer,
            _ => null
        };
    }
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

    public int GetCustomerCountCount(ColorType type)
    {
        return m_Customers.Where(cust => cust.ColorType == type).Count();
    }

    public void AddCustomer(CustomerObject customer)
    {
        if(m_Customers.Count >= m_MaxCustomerCount) { return; }
        m_Customers.Add(new CustomerModel(customer.Instantiate()));
    }
    public ColorType GetRandomColorType() => CustomerColors[Random.Range(0, CustomerColors.Length)];
}