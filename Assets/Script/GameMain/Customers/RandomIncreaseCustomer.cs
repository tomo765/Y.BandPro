using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIncreaseCustomer : CustomersManagerBase
{
    private CustomerUI m_CustomerUI;
    private RandomCustomerModel m_RCModel;

    public RandomCustomerModel RCModel => m_RCModel;

    public RandomIncreaseCustomer(CustomerUI customerUI) : base()
    {
        m_CustomerUI = customerUI;
        m_RCModel = new RandomCustomerModel();
    }

    private void AddTime()
    {
        m_RCModel.SetCullentElapseTime(m_RCModel.CullentElapseTime + Time.deltaTime * m_RCModel.IncreaseMultiplier);
    }

    protected override void AddCustomer()
    {
        if(m_CustomersModel.CustomerCount >= m_CustomersModel.MaxCustomerCount) { return; }
        m_CustomersModel.AddCustomer(new Customer(m_CustomersModel.GetRandomColorType()));
    }


    public override void Start() { }

    public override void FixedUpdate()
    {
        m_CustomerUI.UpdateCustomerCountText(m_CustomersModel.CustomerCount + " / " + m_CustomersModel.MaxCustomerCount);
    }

    public override void Update()
    {
        AddTime();
        if (m_RCModel.CullentElapseTime >= m_RCModel.DefaultIncreaseTime)
        {
            AddCustomer();
            m_RCModel.SetCullentElapseTime(m_RCModel.CullentElapseTime - m_RCModel.DefaultIncreaseTime);
        }
    }
}

    public class RandomCustomerModel
    {
        private float m_DefaultIncreaseTime = 15f;
        private float m_CullentElapseTime = 0;
        private float m_IncreaseMultiplier = 1;

        public float DefaultIncreaseTime => m_DefaultIncreaseTime;
        public float CullentElapseTime => m_CullentElapseTime;
        public float IncreaseMultiplier => m_IncreaseMultiplier;

        public void SetCullentElapseTime(float time) => m_CullentElapseTime = time;
        public void SetIncreaseMultiplier(float mlt) => m_IncreaseMultiplier = mlt;

    }