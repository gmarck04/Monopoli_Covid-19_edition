using UnityEngine;
using UnityEngine.SceneManagement;

public class Code_Menù : MonoBehaviour
{
    private static int Quit = 0;
    private static int Back_int = 0;
    private static int Guida_int = 0;
    private static int Giocatori = 0;
    private static int Login = 0;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Back_int++;
    }
    public void Settings()
    {
        SceneManager.LoadScene(6);
        Back_int++;
    }
    public void Guida()
    {
        SceneManager.LoadScene(8);
        Guida_int++;
        Back_int++;
    }
    public void QuitGame_Menù_1()
    {
        SceneManager.LoadScene(7);
        Quit=+2;
    }
    public void QuitGame_Gioco()
    {
        SceneManager.LoadScene(7);
        Quit=+6;
    }
    public void CPU_vs_P1()
    {
        Giocatori++;
        Login++;
        SceneManager.LoadScene(3);
        Back_int=+2;
        Giocatori=+2;
    }
    public void Multiplayers()
    {        
        SceneManager.LoadScene(2);
        Back_int++;
    }
    public void Giocatore_2()
    {
        Giocatori=+2;
        Login=+2;
        SceneManager.LoadScene(3);
        Back_int++;
    }
    public void Giocatore_3()
    {
        Giocatori=+3;
        Login=+3;
        SceneManager.LoadScene(3);
        Back_int++;
    }
    public void Giocatore_4()
    {
        Giocatori=+4;
        Login=+4;
        SceneManager.LoadScene(3);
        Back_int++;
    }
    private void Giocatori_if()
    {
        if (Giocatori == 0)
        {
            SceneManager.LoadScene(4);
        }
    }
    public void Login_register()
    {
        Login--;
        if (Login == 0)
        {
            SceneManager.LoadScene(5);
        }
    }
    public void Mascherina()
    {
        Giocatori--;
        Giocatori_if();
    }
    public void Siringa()
    {
        Giocatori--;
        Giocatori_if();
    }
    public void Vaccino()
    {
        Giocatori--;
        Giocatori_if();
    }
    public void Amuchina()
    {
        Giocatori--;
        Giocatori_if();
    }
    public void SÌ()
    {
        Application.Quit();
        Debug.Log("OK sei uscito dal gioco");
    }
    public void NO()
    {
        Quit--;
        SceneManager.LoadScene(Quit);
    }
    public void Back()
    {
        Back_int--;
        SceneManager.LoadScene(Back_int);        
    }
}
