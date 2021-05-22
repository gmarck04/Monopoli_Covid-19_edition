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
        choice();
    }

    private void choice()
    {
        switch (screenString)
        {
            case "0":
                {
                    Screen.fullScreen = Screen.fullScreen;
                }
                break;

            case "1":
                {
                    Screen.fullScreen = !Screen.fullScreen;
                }
                break;
        }
    }
}
