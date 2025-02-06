using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiewSound : MonoBehaviour
{
    [SerializeField] private MusicType m_PlayMusicType;
    [SerializeField] private AudioSource m_MainSource;
    [SerializeField] private AudioSource m_SubSource;

    private const float ApproximateRange = 0.01f;

    public MusicType PlayMusicType => m_PlayMusicType;
    public AudioSource MainSource => m_MainSource;
    public bool IsPlaying => m_MainSource.isPlaying;

    public void PlaySound(GenreClips clips, float master, AudioSource mainAudio)
    {
        if(m_PlayMusicType == MusicType.Main) { return; }
        (m_MainSource, m_SubSource) = (m_SubSource, m_MainSource);
        StartCoroutine(GraduallyDecreaseVolume(m_SubSource, 0.05f));
        StartCoroutine(GraduallyIncreaseVolume(m_MainSource, master * clips.Volume, 0.05f));

        m_MainSource.clip = clips.GetAudioClipAsType(m_PlayMusicType);

        m_MainSource.Play();
        m_MainSource.time = mainAudio.time;
    }

    public void StopSound() => m_MainSource.Stop();

    private IEnumerator GraduallyDecreaseVolume(AudioSource target, float t)
    {
        while (target.volume > 0 + ApproximateRange)
        {
            target.volume = Mathf.SmoothStep(target.volume, 0, t);
            yield return null;
        }
        target.Stop();
        target.volume = 0;
    }

    private IEnumerator GraduallyIncreaseVolume(AudioSource target, float targetVolume, float t)
    {
        target.Play();
        while(target.volume < targetVolume - ApproximateRange)
        {
            target.volume = Mathf.SmoothStep(target.volume, targetVolume, t);
            yield return null;
        }
    }
}
