using UnityEngine.SceneManagement;
using UnityEngine;


public class TitlePresenter:MonoBehaviour
{
    private TitleManager m_TitleManager;
    private TitleUI m_TitleUI;
    
    public TitlePresenter(TitleManager titleManager)
    {
        m_TitleManager = titleManager;
    }

    public TitlePresenter(TitleUI titleUI)
    {
        m_TitleUI = titleUI;
    }

    public void Start()
    {
        m_TitleUI.StartButton.onClick += () =>
        {
            m_TitleUI.gameObject.SetActive(false);
        };
    }
}
