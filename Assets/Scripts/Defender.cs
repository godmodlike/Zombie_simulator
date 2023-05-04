using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int m_starCost = 100;

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return m_starCost;
    }
}
