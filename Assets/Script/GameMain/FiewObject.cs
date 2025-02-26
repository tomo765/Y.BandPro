using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiewObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private float m_InComeX;
    [SerializeField] private float m_OutComeX;
    [SerializeField] private float m_PosZ;

    public float MoveSpeed => 5f;
    public Vector3 OutComePos => new Vector3(m_OutComeX, 1, m_PosZ);
    public Vector3 InComePos => new Vector3(m_InComeX, 1, m_PosZ);

    public void SetFlip(bool b) => m_SpriteRenderer.flipX = b;
}
