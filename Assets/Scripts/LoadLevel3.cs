using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadLevel3 : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Level3");
    }
}