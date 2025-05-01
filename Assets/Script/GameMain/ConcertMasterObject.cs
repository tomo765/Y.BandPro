using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcertMasterObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_SpriteRenderer;

    public void SetSprite(Sprite sprite) => m_SpriteRenderer.sprite = sprite;
    public void SetFlip(bool b) => m_SpriteRenderer.flipX = b;

    //private bool m_IsInComing = false;

    //public bool IsInComing => m_IsInComing;

    //public void SetInComing(bool b) => m_IsInComing = b;
}
