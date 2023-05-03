using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    private bool spawn = true;
    [SerializeField] private float m_minSpawnDelay = 1f;
    [SerializeField] private float m_maxSpawnDelay = 5f;
    [SerializeField] private Attacker m_attackerPrefab;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(m_minSpawnDelay, m_maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate
            (m_attackerPrefab, transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform;
    }
}
