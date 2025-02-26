using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

    protected void UpdateCustomersPay(float time)
    {
        if (!SoundManager.Instance.IsPlaySound) { return; }

        GameDataManager.Instance.CustomersModel.UpdateCustomersPay(time);
    }
}

public class CustomersModel
{
    public static Vector3 InitPos => new Vector3(12, 0, Random.Range(-8f , - 0.5f));

    public readonly ColorType[] CustomerColors = { ColorType.Red, ColorType.Green, ColorType.Blue };

    private List<CustomerModel> m_Customers = new List<CustomerModel>();
    private Transform m_CustomerUnifyObject;
    private int m_MaxCustomerCount;

    public System.Action<int> OnAddCustomer;
    public System.Action<int> OnChangeMaxCustomerCount;

    public List<ColorType> AllCustomerColor => m_Customers.Select(c => c.ColorType).ToList();

    public int CustomerCount => m_Customers.Count;
    public int MaxCustomerCount => m_MaxCustomerCount;

    public CustomersModel(int maxCustomerCount, Transform customerUnify)
    {
        m_MaxCustomerCount = maxCustomerCount;
        m_CustomerUnifyObject = customerUnify;
    }

    public int GetCustomerCount(ColorType type) => m_Customers.Where(cust => cust.ColorType == type).Count();

    public void UpdateMaxCustomerCount(int count)
    {
        m_MaxCustomerCount = count;
        OnChangeMaxCustomerCount?.Invoke(m_MaxCustomerCount);
    }
    public void AddCustomer(CustomerObject customer)
    {
        if(m_Customers.Count >= m_MaxCustomerCount) { return; }

        Vector3 from = InitPos;
        Vector3 to = from;
        to.x = Random.Range(-1.5f, GetRightPos(from.z));
        m_Customers.Add(new CustomerModel(customer.Instantiate(from, Quaternion.identity, m_CustomerUnifyObject), to));
        OnAddCustomer?.Invoke(m_Customers.Count);
    }
    public void UpdateCustomersPay(float time)
    {
        for(int i = 0; i < m_Customers.Count; i++) 
        { 
            m_Customers[i].UpdatePay(time); 
        }
    }

    public ColorType GetRandomColorType() => CustomerColors[Random.Range(0, CustomerColors.Length)];

    /// <summary> 下記の2点が通る1次関数にy座標を代入してxを取得する。 </summary>
    /// <remarks> z = 1.3889x - 14.1122</remarks>
    /// <remarks> (4.4, -8) ～ (9.8, -0.5)がカメラの右端に映る位置 </remarks>
    private float GetRightPos(float z) => (z + 14.1122f) / 1.3889f;
}