using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPresenter
{
    private ResultUI m_ResultUI;



    public ResultPresenter(ResultUI resultUI)
    {
        m_ResultUI = resultUI;
    }

    public void Start()
    {
        GameObject fadeUI = (GameObject)Resources.Load("FadeOutUI");
        MonoBehaviour.Instantiate(fadeUI, new Vector3(0f, 0f, 0f), Quaternion.identity);
        FadeUI.Instance.gameObject.SetActive(false);

        m_ResultUI.RetryButton.onClick = async () =>
        {
            FadeUI.Instance.gameObject.SetActive(true);

            await FadeUI.Instance.Fade("GameMain", () => FadeUI.Instance.gameObject.SetActive(false));
        };

        m_ResultUI.TitleButton.onClick = async () =>
        {
            FadeUI.Instance.gameObject.SetActive(true);

            await FadeUI.Instance.Fade("Title", () => FadeUI.Instance.gameObject.SetActive(false));
        };
    }
}
