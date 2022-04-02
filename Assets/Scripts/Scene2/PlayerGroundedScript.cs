using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedScript : MonoBehaviour
{
    [SerializeField] private List<Collider2D> collisionList = new List<Collider2D>();
    public List<Collider2D> CollisionList { get => collisionList; set => collisionList = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!CollisionList.Contains(collision) && collision.CompareTag("Platform") && !PlayerControllerScript.HasTouchedPlatform)
        {
            PlayerControllerScript.HasTouchedPlatform = true;
            CollisionList.Add(collision);
        }

        if(!CollisionList.Contains(collision) && collision.CompareTag("BadGround") && PlayerControllerScript.HasTouchedPlatform)
        {
            GameManagerScript.Happiness--;
            CollisionList.Add(collision);
        }

        if(!CollisionList.Contains(collision))
        {
            CollisionList.Add(collision);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(CollisionList.Contains(collision))
        {
            CollisionList.Remove(collision);
        }
    }
}
