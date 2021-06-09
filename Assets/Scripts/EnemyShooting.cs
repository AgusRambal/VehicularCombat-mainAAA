using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    private float timeBtwShoots;
    public float startTimeBtwShoots;

    public GameObject projectile;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShoots = startTimeBtwShoots;
    }


    void Update()
    {
        if (timeBtwShoots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
