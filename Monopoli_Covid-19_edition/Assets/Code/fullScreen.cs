using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fullScreen : MonoBehaviour
{
    List<string> screen_options = new List<string>() { "SCHERMO INTERO", "SCHERMO RIDOTTO" }; //lista
    public Dropdown screen; //prendo il dropdown e lo nomino screen
    private string screenString;

    // Start is called before the first frame update
    void Start()
    {
        screen.ClearOptions(); //pulisco le opzioni del dropdown
        screen.AddOptions(screen_options); //aggiungo le opzioni contenute nella lista
    }

    // Update is called once per frame
    void Update()
    {
        screenString = screen.value.ToString(); //prendo il valore scelto dall'utente
        choice();
    }

    private void choice()
    {
        switch (screenString)
        {
            case "0":
                {                    
                    Screen.fullScreen = Screen.fullScreen; //fullScreen
                }
                break;

            case "1":
                {
                    Screen.fullScreen = !Screen.fullScreen; //no fullScreen
                }
                break;
        }
    }
}
