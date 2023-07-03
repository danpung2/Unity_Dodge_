using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform _target;
    private float _spawnRate;
    private float _timeAfterSpawn;
    
    void Start()
    {
        _timeAfterSpawn = 0.5f;
        _spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        _target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        _timeAfterSpawn += Time.deltaTime;

        if (_timeAfterSpawn >= _spawnRate)
        {
            _timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(_target);
        }

        _spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }
}
