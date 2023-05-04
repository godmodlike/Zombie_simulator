using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const float TIME_TO_WAIT = 4f;

    private int m_currentSceneIndex;

    private void Start()
    {
        m_currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (m_currentSceneIndex == 0)
            StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(TIME_TO_WAIT);
        LoadNextScene(m_currentSceneIndex);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadNextScene(int index)
    {
        SceneManager.LoadScene(index + 1);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(m_currentSceneIndex);
        Time.timeScale = 1f;
    }

    public void LoadloseScene()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
