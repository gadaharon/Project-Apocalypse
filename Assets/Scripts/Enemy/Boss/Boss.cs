using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject fireBall;
    [SerializeField] Transform fireballSpawner;

    void Start()
    {
        StartCoroutine(ShootProjectiles());
    }

    IEnumerator ShootProjectiles()
    {
        while (true)
        {
            GameObject instance = Instantiate(fireBall, fireballSpawner.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }

}
