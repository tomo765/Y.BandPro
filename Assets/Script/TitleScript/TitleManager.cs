using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : SingletonBehaviour<TitleManager>
{
    private AsyncOperation m_LoadMainAsync;

    private TitleUI m_TitleUI;
    private ReserveUI m_ReserveUI;


    protected override void Awake()
    {
        base.Awake();
    }

    public void SetTitleUI(TitleUI titleUI)
    {
        m_TitleUI = titleUI;
        m_TitleUI.StartButton.onClick.RemoveAllListeners();
        m_TitleUI.StartButton.onClick.AddListener(() =>
        {
            m_TitleUI.SetActive(false);
            m_ReserveUI.SetActive(true);
            if (m_LoadMainAsync != null) { return; }

            //StartCoroutine(LoadBeforeActivate());
        });
    }

    public void SetReserveUI(ReserveUI reserveUI)
    {
        m_ReserveUI = reserveUI;
        //Debug.Log(m_ReserveUI);

        m_ReserveUI.PlayButton.onClick.RemoveAllListeners();
        m_ReserveUI.PlayButton.onClick.AddListener(() =>
        {
            //m_LoadMainAsync.allowSceneActivation = true;
            SceneManager.LoadScene("GameMain");
        });

        m_ReserveUI.BackButton.onClick.RemoveAllListeners();
        m_ReserveUI.BackButton.onClick.AddListener(() =>
        {
            m_TitleUI.SetActive(true);
            m_ReserveUI.SetActive(false);
        });
    }

    //private IEnumerator LoadBeforeActivate()
    //{
    //    m_LoadMainAsync = SceneManager.LoadSceneAsync("GameMain");
    //    while(m_LoadMainAsync.isDone)
    //    {
    //        yield return null;
    //    }

    //    m_LoadMainAsync.allowSceneActivation = false;
    ////}
}
    
    