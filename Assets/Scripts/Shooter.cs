using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject m_projectile;
    [SerializeField] private GameObject gun;
    private GameObject m_projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    private AttackerSpawner myLaneSpawner;
    private Animator m_animator;

    private void Awake()
    {
        if (m_animator == null)
            m_animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        m_projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!m_projectileParent)
        {
            m_projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            // TODO change animation state to attack
            m_animator.SetBool("IsAttacking", true);
        }
        else
        {
            // TODO change animation state to idle
            m_animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y - .22f) <= .5);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(m_projectile, gun.transform.position, transform.rotation);
        projectile.transform.parent = m_projectileParent.transform;
    }
}
