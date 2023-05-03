using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] private float m_walkSpeed = 1f;

    void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(Vector2.left * m_walkSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed) {
        m_walkSpeed = speed;
    }
}
