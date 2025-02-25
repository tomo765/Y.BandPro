using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiewObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private float m_PerformancePosX;
    [SerializeField] private float m_PosZ;

    public float MoveSpeed => 5f;
    public Vector3 OutComePos => new Vector3(-8.8f, 0, m_PosZ);
    public Vector3 InComePos => new Vector3(m_PerformancePosX, 0, m_PosZ);

    public void SetFlip(bool b) => m_SpriteRenderer.flipX = b;
}
