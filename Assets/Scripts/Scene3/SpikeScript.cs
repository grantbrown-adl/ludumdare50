using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Spike");
            GameManagerScript.Happiness--;
            Destroy(transform.parent.gameObject);
        }
    }
}
