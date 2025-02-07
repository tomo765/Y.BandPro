using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerObject : MonoBehaviour
{
    [SerializeField] private ColorType m_ColorType = ColorType.Blue;
    [SerializeField] private SpriteRenderer m_SpriteRenderer;

    public ColorType ColorType => m_ColorType;
    public SpriteRenderer SpriteRenderer => m_SpriteRenderer;

    public CustomerObject Instantiate() => GameObject.Instantiate(this);
    public CustomerObject Instantiate(Vector3 pos, Quaternion rotation) => GameObject.Instantiate(this, pos, rotation);
    public CustomerObject Instantiate(Vector3 pos, Quaternion rotation, Transform parent) => GameObject.Instantiate(this, pos, rotation, parent);
    public CustomerObject Instantiate(Transform parent) => GameObject.Instantiate(this, parent);
}
