using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToSpawn;
    [SerializeField] Transform playerTransform;
    [SerializeField] private static float moveSpeed;
    [SerializeField] private float spawnRange;

    [SerializeField] private float timer;
    [SerializeField] private float countdown;

    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public Transform PlayerTransform { get => playerTransform; }

    private void Start()
    {
        MoveSpeed = 4.0f;
        countdown = 2.0f;
    }

    private void Update()
    {
        TimedSpawn();
    }

    void SpawnObject()
    {
        int randomSpawn = Random.Range(0, objectsToSpawn.Length);

        GameObject gameObject = Instantiate(objectsToSpawn[randomSpawn]);
        gameObject.transform.position = this.transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0.0f, 0.0f);
        gameObject.transform.parent = this.transform;
    }

    void TimedSpawn()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0.0f)
        {
            SpawnObject();
            countdown = timer;
        }
    }
}
