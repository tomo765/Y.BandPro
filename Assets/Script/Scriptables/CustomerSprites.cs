using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerSprites", menuName = "Scriptables/CustomerSprites")]
public class CustomerSprites : ScriptableObject
{
    [SerializeField] private Sprite[] m_RedCustomers;
    [SerializeField] private Sprite[] m_GreenCustomers;
    [SerializeField] private Sprite[] m_BlueCustomers;

    public Sprite GetRandomCustomerSprite(ColorType type)
    {
        return type switch
        {
            ColorType.Red => GetRandomSprite(m_RedCustomers, m_RedCustomers.Length),
            ColorType.Green => GetRandomSprite(m_GreenCustomers, m_GreenCustomers.Length),
            ColorType.Blue => GetRandomSprite(m_BlueCustomers, m_BlueCustomers.Length),
            _ => null
        };

        Sprite GetRandomSprite(Sprite[] sprites, int length) => sprites[Random.Range(0, length-1)];
    }
}
