using UnityEngine.SceneManagement;

public class TitlePresenter
{
    private TitleManager m_TitleManager;


    public TitlePresenter(TitleManager titleManager)
    {
        m_TitleManager = titleManager;
    }

    public void Start()
    {
        m_TitleManager.TitleUI.StartButton.onClick = () =>
        {
            m_TitleManager.TitleUI.SetActive(false);
            m_TitleManager.ReserveUI.SetActive(true);
        };

        m_TitleManager.ReserveUI.PlayButton.onClick = () =>
        {
            SceneManager.LoadScene("GameMain");
        };

        m_TitleManager.ReserveUI.BackButton.onClick = () =>
        {
            m_TitleManager.TitleUI.SetActive(true);
            m_TitleManager.ReserveUI.SetActive(false);
        };
    }
}
