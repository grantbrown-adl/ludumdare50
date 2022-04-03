using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanvasScript : MonoBehaviour
{
    private void Start()
    {
        GameManagerScript.IsPaused = true;
    }

    public void Unpause()
    {
        GameManagerScript.IsPaused = false;
    }
}
