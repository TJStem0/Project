using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    /*for buttons*/
    public void PlayGame()
    {
        SceneManager.LoadScene("Farm");
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
