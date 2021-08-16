using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject gun;

    AttackerSpawner[] spawners;
    AttackerSpawner laneSpawner;
    Animator animator;

    private GameObject projectilePerent;

    private const string PROJECTILE_PERENT_NAME = "Projectiles";

    private void Start()
    {
        CreateProjectilePerent();
        spawners = FindObjectsOfType<AttackerSpawner>();
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void CreateProjectilePerent()
    {
        projectilePerent = GameObject.Find(PROJECTILE_PERENT_NAME);
        if (projectilePerent == null)
        {
            projectilePerent = new GameObject(PROJECTILE_PERENT_NAME);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }


    void SetLaneSpawner()
    {
        foreach(AttackerSpawner spawner in spawners)
        {
            if(Mathf.Round(spawner.transform.position.y) == Mathf.Round(transform.position.y))
            {
                laneSpawner = spawner;
            }
        }
    }


    private bool IsAttackerInLane()
    {
        if (laneSpawner.transform.childCount > 0) return true;
        return false;
    }


    public void Fire()
    {
        var proj = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        proj.transform.parent = projectilePerent.transform;
    }
}
