using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender m_defender;
    private GameObject m_defenderParent;
    private Defender[] m_allDefenders;

    private const string DEFENDER_PARENT_NAME = "Defenders";

    private void Awake()
    {
        CreateDefenderParent();
        m_allDefenders = FindObjectsOfType<Defender>();
    }

    private void CreateDefenderParent()
    {
        m_defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!m_defenderParent)
        {
            m_defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        m_defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = m_defender.GetStarCost();
        bool isOne = false;
        foreach (Defender df in m_allDefenders)
        {
            if (df.transform.position.Equals(gridPos))
            {
                isOne = true;
            }
        }
        if (starDisplay.HaveEnoughStars(defenderCost) && !isOne)
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender;
        if (m_defender != null)
        {
            newDefender = Instantiate(m_defender, roundedPos, Quaternion.identity) as Defender;
            newDefender.transform.parent = m_defenderParent.transform;
        }
    }
}
