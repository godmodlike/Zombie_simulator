using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int m_stars = 100;
    private TextMeshProUGUI m_starText;

    private void Awake()
    {
        m_starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        m_starText.text = m_stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return m_stars >= amount;
    }

    public void AddStars(int amount)
    {
        m_stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (m_stars >= amount)
        {
            m_stars -= amount;
            UpdateDisplay();
        }
    }
}
