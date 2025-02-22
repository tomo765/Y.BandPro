using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using Cysharp.Threading.Tasks;


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
        Instantiate(fadeUI,new Vector3 (0f,0f,0f),Quaternion.identity);
        FadeUI.Instance.gameObject.SetActive(false);

        m_TitleManager.TitleUI.StartButton.onClick = () =>
        {
            m_TitleManager.TitleUI.SetActive(false);
            m_TitleManager.ReserveUI.SetActive(true);
        };

        m_TitleManager.ReserveUI.PlayButton.onClick = async() =>
        {
            FadeUI.Instance.gameObject.SetActive(true);

            await FadeUI.Instance.Fade("GameMain", () => FadeUI.Instance.gameObject.SetActive(false));

        };

        m_TitleManager.ReserveUI.BackButton.onClick = () =>
        {
            m_TitleManager.TitleUI.SetActive(true);
            m_TitleManager.ReserveUI.SetActive(false);
        };
    }
}
