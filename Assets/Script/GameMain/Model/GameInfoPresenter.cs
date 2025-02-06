using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoPresenter
{
    private GameInfoUI m_GameInfoUI;
    private float m_MaxSoundTime;

    public GameInfoPresenter(GameInfoUI gameInfoUI)
    {
        m_GameInfoUI = gameInfoUI;
    }

    public void Start()
    {
        m_MaxSoundTime = ScriptablesManager.Instance.MainClips.GetAudioClipAsType(MusicType.Mus1).length;
        m_GameInfoUI.TimerSlider.maxValue = m_MaxSoundTime;
        m_GameInfoUI.TimerSlider.value = m_MaxSoundTime;
    }

    public void FixedUpdate()
    {
        m_GameInfoUI.TimerSlider.value = m_MaxSoundTime - SoundManager.Instance.MainSoundTime;
    }
}
