using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadLevelTwo : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}