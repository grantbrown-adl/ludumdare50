using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3Spawned : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int happiness;
    [SerializeField] GameObject broken;
    [SerializeField] private int number;

    private void Start()
    {
        moveSpeed = S2Spawner.MoveSpeed;
    }

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if(transform.position.x < -10)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //GameObject go = Instantiate(broken, this.transform.position, Quaternion.identity);
            //Destroy(go, 2.0f);
            GameManagerScript.Happiness += happiness;
            Destroy(this.gameObject);
        }

        if(collision.CompareTag("Despawn"))
        {
            DespawnScript.IntScore++;
            //GameManagerScript.Happiness += happiness;
            Destroy(this.gameObject);

        }
    }
}
