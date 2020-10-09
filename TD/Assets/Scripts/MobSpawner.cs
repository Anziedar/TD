﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public class MobSpawner : MonoBehaviour
    {
        [SerializeField] public byte numberOfMobs;

        [SerializeField] private GameObject _enemyPrefab;

        [SerializeField] private byte enemySpawnInterval;

        [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
        [SerializeField] public List<Transform> waypoints = new List<Transform>();

        [HideInInspector] public List<GameObject> listOfEnemies = new List<GameObject>();

        void Start()
        {
            StartCoroutine(routine: Spawner());
        }

        void Update()
        {

        }
        void SpawnAMob()
        {
            listOfEnemies.Add(GameObject.Instantiate(_enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity) as GameObject);
        }
         private IEnumerator Spawner()
        {
            while (listOfEnemies.Count < numberOfMobs)
            {
                SpawnAMob();
                //Debug.Log($"Spawned an enemy");
                //Debug.Log($"Total number of enemies: {listOfEnemies.Count}");
                yield return new WaitForSeconds(enemySpawnInterval);
            }
        }
    }
}