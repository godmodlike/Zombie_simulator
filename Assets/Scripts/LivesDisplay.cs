using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private int m_lives = 5;
    [SerializeField] private int m_damage = 1;
    private TextMeshProUGUI m_livesText;

    private void Awake()
    {
        m_livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        m_livesText.text = m_lives.ToString();
    }

    public void TakeLife()
    {
        m_lives -= m_damage;
        UpdateDisplay();
        if (m_lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
