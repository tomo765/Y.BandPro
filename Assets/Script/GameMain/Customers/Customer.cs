using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer
{
    private ColorType m_ColorType;
    private SpriteRenderer m_SpriteRenderer;

    public ColorType ColorType => m_ColorType;

    public Customer(ColorType type)
    {
        m_ColorType = type;
        m_SpriteRenderer = new GameObject().AddComponent<SpriteRenderer>();
        m_SpriteRenderer.name = "Customer";
        m_SpriteRenderer.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[type];
    }

    public void Start()
    {
        
    }


    public void Update()
    {
        
    }
}
