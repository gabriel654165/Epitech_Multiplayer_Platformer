using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene("new_world");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
