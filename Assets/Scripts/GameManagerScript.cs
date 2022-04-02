using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private static int happiness = 0;
    [SerializeField] private int score = 0;
    [SerializeField] private string nameOfScene;

    public static int Happiness { get => happiness; set => happiness = value; }

    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            happiness++;

        slider.value = happiness;
        score = happiness;

        if(happiness >= 10)
        {
            happiness = 0;
            LoadScene(nameOfScene);
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
