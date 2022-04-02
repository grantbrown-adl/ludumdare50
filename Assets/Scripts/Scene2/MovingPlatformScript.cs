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

        //spawnerScript = GetComponentInParent<S2Spawner>();
    }

    private void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        if(transform.position.x > 10 || transform.position.x < -10)
            Destroy(this.gameObject);
    }

    /*    private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.GetComponent<PlayerControllerScript>())
            {
                collision.transform.parent = this.gameObject.transform;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.GetComponent<PlayerControllerScript>())
            {
                collision.transform.parent = null;
            }
        }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.parent = this.gameObject.transform;
            //GameManagerScript.Happiness += happiness;
            //Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
