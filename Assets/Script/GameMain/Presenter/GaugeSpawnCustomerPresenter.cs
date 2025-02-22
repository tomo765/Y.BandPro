using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeSpawnCustomerPresenter : CustomersPresenterBase
{


    public GaugeSpawnCustomerPresenter(CustomerUI customerUI) : base(customerUI)
    {
    }

    protected override void AddCustomer(ColorType type)
    {

    }

    public override void Start()
    {
        
    }

    // Update か FixedUpdate で一定時間経過後、
    public override void Update()
    {
        
    }
}

public class GaugeCustomerModel
{
    //必要ならそれぞれの色の客が増えるスピードをここで管理する (変数必要ないかも)
}