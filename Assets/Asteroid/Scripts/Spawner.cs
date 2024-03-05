using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private GameObject[] EnemyPrefabs;

    [Header("Settings")]
    [SerializeField] private float spawnRate;
    [SerializeField] private float maxScale;
    private float scale;
    [SerializeField] private float spawnRateEnemy;


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.IsGameState())
        {
            SpawnAsteroid();

        }



    }



    private void SpawnAsteroid()
    {
        spawnRate -= Time.deltaTime; //! spawnrate i azaltıyoruz
        if (spawnRate < 0)
        {
            spawnRate = UnityEngine.Random.Range(0.5f, 1.5f);
            scale = UnityEngine.Random.Range(0.5f, maxScale + 1.0f);//! scale i random bir değer atıyoruz
            int randomAsteroid = UnityEngine.Random.Range(0, asteroidPrefabs.Length);
            GameObject asteroid = Instantiate(asteroidPrefabs[randomAsteroid], transform.position, Quaternion.identity);

            asteroid.transform.position = new Vector3(UnityEngine.Random.Range(-2.5f, 2.5f), transform.position.y, 0);
            asteroid.transform.localScale = new Vector3(scale, scale, 0);
        }

    }
}
