using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
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

    public void LoadNextScene(int index)
    {
        SceneManager.LoadScene(index + 1);
    }
}
