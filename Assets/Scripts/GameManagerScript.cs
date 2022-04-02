using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private static int happiness = 0;

    public static int Happiness { get => happiness; set => happiness = value; }

    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            happiness++;

        slider.value = happiness;

        if(happiness >= 10)
        {
            happiness = 0;
            if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
