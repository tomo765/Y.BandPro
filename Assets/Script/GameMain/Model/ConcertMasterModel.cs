using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcertMasterModel
{
    private const float MoveSpeed = 5f;
    private static readonly Vector3 CenterPos = new Vector3(0, 0, -5);
    private static readonly Vector3 OutPos = new Vector3(-8.5f, 0, -5);

    private ConcertMasterObject m_ConcertMasters;
    private Tween m_Tween;
    private int m_CullentSelect;

    private ConcertMasterModel() { }
    public ConcertMasterModel(ConcertMasterObject concertMasters)
    {
        m_ConcertMasters = concertMasters;
    }

    public void InCome(Sprite sprite)
    {
        int index = m_CullentSelect;
        Transform inComer = m_ConcertMasters.transform;

        m_ConcertMasters.SetSprite(sprite);
        m_ConcertMasters.SetFlip(false);

        m_Tween?.Kill();
        m_Tween = inComer.transform.DOMove(CenterPos, Mathf.Abs(inComer.position.x - CenterPos.x) / MoveSpeed)
                        .SetEase(Ease.Linear)
                        .OnComplete(() => { m_Tween = null; });
    }

    public void OutCome()
    {
        int index = m_CullentSelect;

        m_ConcertMasters.SetFlip(true);

        Transform outComer = m_ConcertMasters.transform;
        m_Tween?.Kill();
        m_Tween = outComer.transform.DOMove(OutPos, Mathf.Abs(outComer.position.x - OutPos.x) / MoveSpeed)
                        .SetEase(Ease.Linear)
                        .OnComplete(() => { m_Tween = null; });
    }
}
