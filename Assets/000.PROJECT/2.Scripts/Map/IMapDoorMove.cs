using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IMapDoorMove : MonoBehaviour
{
    private GameObject LoadingScene;
    void Awake()
    {
        LoadingScene = GameObject.FindGameObjectWithTag("Loading"); //로딩씬 매니저..
    }
    void OnTriggerEnter(Collider other) //문에 닿으면
    {
        if(other.tag == "Player") //플레이어가 문에 닿았을 때
        {
            if (SceneManager.GetActiveScene().name == "NewTristrum") //현재맵이 마을일 때
            {
                //로딩씬매니져에 ILoadingScript안에 있는 LoadScene에 씬이름을 주면서 함수 호출
                LoadingScene.GetComponent<ILoadingScript>().LoadScene("SilverTop");
            }

            if (SceneManager.GetActiveScene().name == "SilverTop")
            {
                LoadingScene.GetComponent<ILoadingScript>().LoadScene("NewTristrum");
            } 
        }
    }

}


