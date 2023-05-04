using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private float m_waitToLoad = 4f;
    [SerializeField] private GameObject winLabel;
    [SerializeField] private GameObject loseLabel;
    private int m_numberOfAttacks = 0;
    private bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        m_numberOfAttacks++;
    }

    public void AttackerKilled()
    {
        m_numberOfAttacks--;
        if (m_numberOfAttacks <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(m_waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene(0);
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
