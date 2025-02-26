using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcertMasterObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private float m_InComeX;
    [SerializeField] private float m_OutComeX;
    [SerializeField] private float m_PosZ;
    [SerializeField] private float m_Speed = 5;

    public Vector3 InComePos => new Vector3(m_InComeX, 1, m_PosZ);
    public Vector3 OutComePos => new Vector3(m_OutComeX, 1, m_PosZ);
    public float Speed => m_Speed;

    public void SetSprite(Sprite sprite) => m_SpriteRenderer.sprite = sprite;
    public void SetFlip(bool b) => m_SpriteRenderer.flipX = b;
}
