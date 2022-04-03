using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    //[SerializeField] private S2Spawner spawnerScript;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int happiness;
    [SerializeField] private GameObject polarity;

    private void Start()
    {
        if(this.transform.position.x < 0)
            moveSpeed = S2Spawner.MoveSpeed;
        else
            moveSpeed = -S2Spawner.MoveSpeed;
    }

    private void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        if(transform.position.x > 10 || transform.position.x < -10)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.parent = this.gameObject.transform;
            float rand = Random.Range(1.0f, 3.0f);

            StartCoroutine(Wait(rand, collision));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }

    IEnumerator Wait(float time, Collider2D collider)
    {
        yield return new WaitForSeconds(time);

        collider.transform.parent = null;
        Destroy(this.gameObject);
    }
}
