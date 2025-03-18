using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SoundManager : SingletonBehaviour<SoundManager>
{
    [SerializeField] private FiewSound m_MainSound;
    [SerializeField] private FiewSound m_Fiew1Sound;
    [SerializeField] private FiewSound m_Fiew2Sound;
    [SerializeField] private FiewSound m_Fiew3Sound;

    private static float m_MasterVolume = 1;

    public UnityEngine.Events.UnityEvent OnFinishMainSound { get; } = new UnityEngine.Events.UnityEvent();
    public float MainSoundTime => m_MainSound.MainSource.time;
    public float SoundLength => m_MainSound.MainSource.clip.length;
    public bool IsPlaySound => m_MainSound.IsPlaying;

    protected override void Awake()
    {
        base.Awake();
    }

    public async UniTask StartMainSound()
    {
        m_MainSound.MainSource.time = 0;
        m_MainSound.MainSource.volume = m_MasterVolume;
        m_MainSound.MainSource.Play();

        Debug.Log ("m_MasterVolume " + m_MasterVolume);
        
        await UniTask.WaitUntil(() => !m_MainSound.IsPlaying);
        OnFinishMainSound?.Invoke();
    }
    public void StartPlaySounds()
    {
        m_Fiew1Sound.MainSource.Play();
        m_Fiew2Sound.MainSource.Play();
        m_Fiew3Sound.MainSource.Play();

        m_Fiew1Sound.MainSource.time = MainSoundTime;
        m_Fiew2Sound.MainSource.time = MainSoundTime;
        m_Fiew3Sound.MainSource.time = MainSoundTime;
    }

    public void PlaySound(GenreClips clips, int fiewNumber)
    {
        GetFiewSound(fiewNumber).PlaySound(clips, m_MasterVolume, m_MainSound.MainSource);
    }

    public void StopSound(int index)
    {
        GetFiewSound(index).StopSound();
    }

    public static void SetMasterVolume(float val)
    {
        m_MasterVolume = val;
    }

    private FiewSound GetFiewSound(int index)
    {
        return index switch
        {
            1 => m_Fiew1Sound,
            2 => m_Fiew2Sound,
            3 => m_Fiew3Sound,
            _ => null,
        };
    }
}

#if UNITY_EDITOR
public partial class SoundManager : SingletonBehaviour<SoundManager>
{
    [Header("Debug"), Space(10)]
    [SerializeField, Range(-3, 3)] private float SoundPitch = 1;

    private void Update()
    {
        OnPitchValueChange();
    }

    private void OnPitchValueChange()
    {
        if(m_MainSound.MainSource.pitch == SoundPitch) { return; }

        m_MainSound.MainSource.pitch = SoundPitch;
        m_Fiew1Sound.MainSource.pitch = SoundPitch;
        m_Fiew2Sound.MainSource.pitch = SoundPitch;
        m_Fiew3Sound.MainSource.pitch = SoundPitch;
    }
}

#endif