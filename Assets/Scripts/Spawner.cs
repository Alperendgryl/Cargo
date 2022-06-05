using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float nextSpawnTime;
    [SerializeField] float delay;
    [SerializeField] GameObject prefab;

    void Update()
    {
        if (ShouldSpawn()) Spawn();       
    }

    bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }

    void Spawn()
    {
        nextSpawnTime = Time.time + delay;
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
