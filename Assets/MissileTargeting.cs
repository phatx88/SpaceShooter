using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTargeting : MonoBehaviour
{
    public Transform target;
    public float speed = 0.5f;
    public float rotateSpeed = 360f; // Rotation speed of the missile
    public float searchRadius = 100f; // Adjust according to your game needs

    void Update()
    {
        if (target == null)
        {
            // Find the nearest enemy with the "Enemy" tag
            FindNearestEnemy();
        }

        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

            // Smoothly rotate towards the target
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotateSpeed * Time.deltaTime);

            // Move forward
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else
        {
            // Move forward without a target
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < closestDistance && distanceToEnemy <= searchRadius)
            {
                closestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
    }
}
