using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float m_levelTime = 10;
    private bool triggeredLevelFinished = false;

    private void Update()
    {
        if (triggeredLevelFinished)
            return;
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / m_levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= m_levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
