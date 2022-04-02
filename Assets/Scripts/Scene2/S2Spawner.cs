using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Spawner : MonoBehaviour
{
    [SerializeField] private bool moveRight;
    [SerializeField] private Vector2[] spawnPositions;
    [SerializeField] GameObject[] objectsToSpawn;

    [SerializeField] private static float moveSpeed;
    [SerializeField] private float viewMoveSpeed;

    [SerializeField] private float timer;
    [SerializeField] private float countdown;
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private void Start()
    {
        MoveSpeed = viewMoveSpeed;
        countdown = Random.Range(2.0f, 5.0f);
    }

    private void Update()
    {
        TimedSpawn();
    }

    void SpawnObject()
    {
        int randomSpawn = Random.Range(0, objectsToSpawn.Length);

        GameObject gameObject = Instantiate(objectsToSpawn[randomSpawn]);
        gameObject.transform.position = this.transform.position;
        gameObject.transform.parent = this.transform;
    }

    void TimedSpawn()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0.0f)
        {
            SpawnObject();
            countdown = Random.Range(2.0f, timer);
        }
    }
}
