using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    [SerializeField] private SpawnerScript spawnerScript;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int happiness;
    [SerializeField] private GameObject polarity;

    private void Start()
    {
        moveSpeed = SpawnerScript.MoveSpeed;
        spawnerScript = GetComponentInParent<SpawnerScript>();
    }

    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        float distToPlayer = Vector2.Distance(spawnerScript.PlayerTransform.position, transform.position);

        if(distToPlayer < 2.0f)
            polarity.SetActive(true);
        else
            polarity.SetActive(false);

        if(transform.position.y > 6)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManagerScript.Happiness += happiness;
            Destroy(this.gameObject);
        }
    }
}
