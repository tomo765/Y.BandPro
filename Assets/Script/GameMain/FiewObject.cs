using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiewObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private float m_PerformancePosX;

    public float MoveSpeed => 5f;
    public readonly Vector3 OutComePos = new Vector3(-8.8f, 0, -4.3f);
    public Vector3 InComePos => new Vector3(m_PerformancePosX, 0, OutComePos.z);

    public void SetFlip(bool b) => m_SpriteRenderer.flipX = b;
}
