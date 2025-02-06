using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonBehaviour<SoundManager>
{
    [SerializeField] private FiewSound m_MainSound;
    [SerializeField] private FiewSound m_Fiew1Sound;
    [SerializeField] private FiewSound m_Fiew2Sound;
    [SerializeField] private FiewSound m_Fiew3Sound;

    [SerializeField, Space(5)] private float m_MasterVolume;

    public float MainSoundTime => m_MainSound.MainSource.time;
    public bool IsPlaySound => m_MainSound.IsPlaying;

    protected override void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(this);
    }

    public void PlaySound(GenreClips clips, int fiewNumber)
    {
        if(fiewNumber == 1) { m_Fiew1Sound.PlaySound(clips, m_MasterVolume, m_MainSound.MainSource); }
        else if(fiewNumber == 2) { m_Fiew2Sound.PlaySound(clips, m_MasterVolume, m_MainSound.MainSource); }
        else { m_Fiew3Sound.PlaySound(clips, m_MasterVolume, m_MainSound.MainSource); }
    }
}
