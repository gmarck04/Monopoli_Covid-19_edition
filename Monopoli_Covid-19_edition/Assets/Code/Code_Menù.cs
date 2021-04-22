using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Code_Menù : MonoBehaviour
{
    private static int Quit = 0;
    private static int Back_int = 0;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings_Menù_1()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame_Menù_1()
    {
        SceneManager.LoadScene(3);
    }
    public void SÌ()
    {
        Application.Quit();
        Debug.Log("OK");
    }
    public void NO()
    {
        SceneManager.LoadScene(Quit);
    }
    public void Back()
    {
        SceneManager.LoadScene(Back_int);
    }
}
