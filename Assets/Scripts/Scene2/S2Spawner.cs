using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Spawner : MonoBehaviour
{
    [SerializeField] private Vector2[] spawnPositions;
    [SerializeField] GameObject[] objectsToSpawn;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private static float moveSpeed;
    [SerializeField] private float viewMoveSpeed;

    [SerializeField] private float timerMax;
    [SerializeField] private float timerMin;
    [SerializeField] private float countdown;
    [SerializeField] private bool isSceneThree;
    [SerializeField] private bool spawnConstant;

    [SerializeField] private bool moveRight;
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private void Start()
    {
        MoveSpeed = viewMoveSpeed;
        countdown = 1f;
    }

    private void Update()
    {
        TimedSpawn();
    }

    void SpawnObject()
    {
        if(playerTransform.position.y > (transform.position.y + 1.75f) && !isSceneThree && !spawnConstant)
        {
        }
        else
        {
            int randomSpawn = Random.Range(0, objectsToSpawn.Length);

            GameObject gameObject = Instantiate(objectsToSpawn[randomSpawn]);

/*            if(isSceneThree)
            {
                int rnd = Random.Range(1, 100);
                if(rnd > 50)
                    gameObject.transform.position = this.transform.position;
                else
                    gameObject.transform.position = this.transform.position + new Vector3(0, 1.0f, 0);
            }
            else*/
            gameObject.transform.position = this.transform.position;

            gameObject.transform.parent = this.transform;
        }
    }

    void TimedSpawn()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0.0f)
        {
            SpawnObject();
            countdown = Random.Range(timerMin, timerMax);
        }
    }
}
