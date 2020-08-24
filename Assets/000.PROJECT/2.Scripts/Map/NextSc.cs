using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSc : MonoBehaviour
{
    private GameObject LoadingScene;
    void Awake()
    {
        LoadingScene = GameObject.FindGameObjectWithTag("Loading");
    }

    public void OnBtnScene()
    {
        if (SceneManager.GetActiveScene().name == "NewTristrum")
        {
            LoadingScene.GetComponent<ILoadingScript>().LoadScene("SilverTop");
        }

        if (SceneManager.GetActiveScene().name == "SilverTop")
        {
            LoadingScene.GetComponent<ILoadingScript>().LoadScene("Crystal Corridor");
        }

        if (SceneManager.GetActiveScene().name == "Crystal Corridor")
        {
            LoadingScene.GetComponent<ILoadingScript>().LoadScene("Diablo 2Phase");
        }

        if (SceneManager.GetActiveScene().name == "Diablo 2Phase")
        {
            LoadingScene.GetComponent<ILoadingScript>().LoadScene("Crystal CorridorLast");
        }

        if (SceneManager.GetActiveScene().name == "Crystal CorridorLast")
        {
            LoadingScene.GetComponent<ILoadingScript>().LoadScene("NewTristrum");
        }
    }
}
