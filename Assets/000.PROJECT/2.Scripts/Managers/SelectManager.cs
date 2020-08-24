using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    [Header("Hero Select")]
    public GameObject[] Char;
    public GameObject[] CharEx;

    public GameObject Sel;

    [Header("Create Error")]
    public Text ErrorMsg;
    public Image ErrorImg;
    public InputField inputField;

    [Header("Hero Animator")]
    public Animator DevilHunter;
    public Animator Wizard;
    public Animator Monk;
    public Animator Barbarian;

    void Awake()
    {
        ErrorMsg.color = new Color(255, 0, 0, 200);
        ErrorMsg.gameObject.SetActive(false);
        ErrorImg.enabled = false;

        foreach (GameObject CharArr in Char)
        {
            CharArr.SetActive(false);
        }
        foreach(GameObject ExArr in CharEx)
        {
            ExArr.SetActive(false);
        }
    }

    void Start()
    {
        Char[0].SetActive(true);
        CharEx[0].SetActive(true);
        Sel = Char[0];
        DevilHunter.SetTrigger("Anim");
    }

    public void OnClickDevilHunter()
    {
        foreach (GameObject CharArr in Char)
        {
            CharArr.SetActive(false);
        }
        foreach (GameObject ExArr in CharEx)
        {
            ExArr.SetActive(false);
        }

        Char[0].SetActive(true);
        CharEx[0].SetActive(true);
        Sel = Char[0];
        DevilHunter.SetTrigger("Anim");
    }

    public void OnClickWizard()
    {
        foreach (GameObject CharArr in Char)
        {
            CharArr.SetActive(false);
        }
        foreach (GameObject ExArr in CharEx)
        {
            ExArr.SetActive(false);
        }

        Char[1].SetActive(true);
        CharEx[1].SetActive(true);
        Sel = Char[1];
        Wizard.SetTrigger("Anim");
    }


    public void OnClickMonk()
    {
        foreach (GameObject CharArr in Char)
        {
            CharArr.SetActive(false);
        }
        foreach (GameObject ExArr in CharEx)
        {
            ExArr.SetActive(false);
        }

        Char[2].SetActive(true);
        CharEx[2].SetActive(true);
        Sel = Char[2];
        Monk.SetTrigger("Anim");
    }

    public void OnClickBarbarian()
    {
        foreach (GameObject CharArr in Char)
        {
            CharArr.SetActive(false);
        }
        foreach (GameObject ExArr in CharEx)
        {
            ExArr.SetActive(false);
        }

        Char[3].SetActive(true);
        CharEx[3].SetActive(true);
        Sel = Char[3];
        Barbarian.SetTrigger("Anim");
    }

    public void OnClickCreate()
    {
        if(inputField.text != string.Empty && inputField.text.Length < 10)
        {
            SceneManager.LoadScene("NewTristrum");            
        }
        else if(inputField.text == string.Empty)
        {
            ErrorImg.enabled = true;
            ErrorMsg.text = "생성할 영웅의 이름을 입력하세요.";
            
        }
        else if(inputField.text.Length >10)
        {
            ErrorImg.enabled = true;
            ErrorMsg.text = "생성 가능한 이름의 최대 길이는 10자 입니다.";
        }
    }

    public void OnClickShowError()
    {
        ErrorMsg.gameObject.SetActive(true);
    }
}
