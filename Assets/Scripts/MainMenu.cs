using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionMenu;
    public GameObject ChapterMenu;
    void Start()
    {
        OptionMenu.gameObject.SetActive(false);
        ChapterMenu.gameObject.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
    
}
