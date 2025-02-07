using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    private CustomerObject m_CustomerObject;

    public ColorType ColorType => m_CustomerObject.ColorType;

    public Customer(CustomerObject customerObject)
    {
        m_CustomerObject = customerObject;
        //m_SpriteRenderer.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[type];
    }

    public void Start()
    {
        
    }


    public void Update()
    {
        
    }
}
