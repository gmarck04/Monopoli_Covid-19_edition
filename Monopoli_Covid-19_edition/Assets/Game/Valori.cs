using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valori : MonoBehaviour
{
    List<string> money_options = new List<string>() { "1480 EURO", "ALTRO (PRESTO DISPONIBILE)" };
    List<string> time_options = new List<string>() { "100 MINUTI", "ALTRO (PRESTO DISPONIBILE)" };
    public Dropdown money;
    public Dropdown time;
    public InputField money_input;
    public InputField time_input;
    public GameObject money_btm;
    private string moneyString;
    private string timeString;
    public int money_int = 0;
    public int time_int = 0;

    // Start is called before the first frame update
    void Start()
    {
        money.ClearOptions();
        money.AddOptions(money_options);

        time.ClearOptions();
        time.AddOptions(time_options);

        //money_btm.SetActive(false);
    }

    private void Update()
    {
        timeString = time.value.ToString();
        moneyString = money.value.ToString();

        if(moneyString == "1480 EURO")
        {
            money_int = 1480;
        }

        if (moneyString == "100 MINUTI")
        {
            time_int = 100;
        }

        //if (moneyString == "ALTRO")
        //    money_btm.SetActive(true);
    }

    // Update is called once per frame
    public void time_refresh()
    {       
        Debug.Log(timeString);
        choice_time();
    }
    
    public void money_refresh()
    {
        Debug.Log(moneyString);
        choice_money();
    }

    private void choice_money()
    {
        switch (moneyString)
        {
            case "1480 EURO":
                {
                    money_int = 1480;
                }
                break;

            //case "ALTRO":
            //    {
            //        string money_input_string = "";
            //        money_input_string = money_input.text;

            //        try
            //        {
            //            money_int = Convert.ToInt32(money_input_string);                        
            //        }
            //        catch (FormatException)
            //        {
            //            Debug.Log("sei stupido? 01");
            //        }
            //    }
            //    break;
        }
        Debug.Log(money_int);
    }

    private void choice_time()
    {
        switch (moneyString)
        {
            case "100 MINUTI":
                {
                    time_int = 100;
                }
                break;

        //    case "ALTRO":
        //        {
        //            string time_input_string = "";
        //            time_input_string = money_input.text;

        //            try
        //            {
        //                time_int = Convert.ToInt32(time_input_string);                        
        //            }
        //            catch (FormatException)
        //            {
        //                Debug.Log("sei stupido? 02");
        //            }
        //        }
        //        break;                
        }
        Debug.Log(time_int);
    }
}
