using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerModel
{
    private const int NyuutenPay = 50;
    private const int KeizokuPay = 10;

    private const float PayMoneyTime = 10f;
    private const float MoveSpeed = 5f;

    private CustomerObject m_CustomerObject;
    private float m_CullentTime = 0;

    public ColorType ColorType => m_CustomerObject.ColorType;

    public bool PayableMoney => m_CullentTime >= PayMoneyTime;

    private CustomerModel() { }
    public CustomerModel(CustomerObject customerObject, Vector3 to)
    {
        m_CustomerObject = customerObject;
        MoveTo(to);

        GameDataManager.Instance.GameInfoModel.AddMoney(NyuutenPay);
    }

    private void MoveTo(Vector3 to)
    {
        float time = Mathf.Abs(to.x - m_CustomerObject.transform.position.x) / MoveSpeed;
        m_CustomerObject.transform.DOMove(to, time)
                                  .SetEase(Ease.Linear);
    }

    public void UpdatePay(float time)
    {
        m_CullentTime += time;
        if(m_CullentTime < PayMoneyTime) { return; }

        m_CullentTime = 0;
        GameDataManager.Instance.GameInfoModel.AddMoney(KeizokuPay);
    }
}
