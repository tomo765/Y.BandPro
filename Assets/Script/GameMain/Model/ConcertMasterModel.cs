using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcertMasterModel
{
    private const float MoveSpeed = 5f;

    private ConcertMasterObject m_ConcertMasters;
    private Tween m_Tween;

    private ConcertMasterModel() { }
    public ConcertMasterModel(ConcertMasterObject concertMasters)
    {
        m_ConcertMasters = concertMasters;
    }

    public void InCome(Sprite sprite) => MoveAt(m_ConcertMasters.InComePos, sprite, false);

    public void OutCome() => MoveAt(m_ConcertMasters.OutComePos, null, true);

    private void MoveAt(Vector3 to, Sprite sprite = null, bool flip = false)
    {
        if(sprite != null) { m_ConcertMasters.SetSprite(sprite); }
        m_ConcertMasters.SetFlip(flip);

        m_Tween?.Kill();
        m_Tween = m_ConcertMasters.transform.DOMove(to, Mathf.Abs(m_ConcertMasters.transform.position.x - to.x) / m_ConcertMasters.Speed)
                                            .SetEase(Ease.Linear)
                                            .OnComplete(() => { m_Tween = null; });
    }
}
