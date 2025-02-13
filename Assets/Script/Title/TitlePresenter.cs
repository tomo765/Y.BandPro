using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


public class TitlePresenter:MonoBehaviour
{
    private TitleManager m_TitleManager;
    
    
    public TitlePresenter(TitleManager titleManager)
    {
        m_TitleManager = titleManager;
    }

    public void Start()
    {
        GameObject fadeUI = (GameObject)Resources.Load("FadeOutUI");

        m_TitleManager.TitleUI.StartButton.onClick = () =>
        {
            m_TitleManager.TitleUI.SetActive(false);
            m_TitleManager.ReserveUI.SetActive(true);
        };

        m_TitleManager.ReserveUI.PlayButton.onClick = () =>
        {
            Instantiate(fadeUI,new Vector3 (0f,0f,0f),Quaternion.identity);
            //SceneManager.LoadScene("GameMain");
        };

        m_TitleManager.ReserveUI.BackButton.onClick = () =>
        {
            m_TitleManager.TitleUI.SetActive(true);
            m_TitleManager.ReserveUI.SetActive(false);
        };
    }
}
