using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fullScreen : MonoBehaviour
{
    List<string> screen_options = new List<string>() { "SCHERMO INTERO", "SCHERMO RIDOTTO" };
    public Dropdown screen;
    private string screenString;

    // Start is called before the first frame update
    void Start()
    {
        screen.ClearOptions();
        screen.AddOptions(screen_options);
    }

    // Update is called once per frame
    void Update()
    {
        screenString = screen.value.ToString();
        //Debug.Log(screenString);
        choice();
    }

    private void choice()
    {
        switch (screenString)
        {
            case "SCHERMO INTERO":
                {
                    Screen.fullScreen = true;
                }
                break;

            case "SCHERMO RIDOTTO":
                {
                    Screen.fullScreen = false;
                }
                break;
        }
    }
}
