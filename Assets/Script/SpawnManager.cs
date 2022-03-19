using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float zPositionRange = 24;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 3.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {



    }

    void SpawnRandomEnemy()
    {
        float RanZPos = Random.Range(-zPositionRange, zPositionRange);
        int enemyPrefabIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 RanPos = new Vector3(-24, 1, RanZPos);
        Instantiate(enemyPrefabs[enemyPrefabIndex], RanPos,
            enemyPrefabs[enemyPrefabIndex].transform.rotation);

    }
}
