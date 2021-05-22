using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Valori : MonoBehaviour
{
    List<string> money_options = new List<string>() { "1480 EURO", "ALTRO" };
    List<string> time_options = new List<string>() { "100 MINUTI", "ALTRO" };
    public Dropdown money;
    public Dropdown time;
    public InputField money_input;
    public InputField time_input;
    public GameObject money_btm;
    public GameObject time_btm;
    private string moneyString;
    private string timeString;
    public int money_1_int = 0;
    public int time_1_int = 0;

    // Start is called before the first frame update
    void Start()
    {
        money.ClearOptions();
        money.AddOptions(money_options);

        time.ClearOptions();
        time.AddOptions(time_options);

        money_btm.SetActive(false);
        time_btm.SetActive(false);
    }

    private void Update()
    {
        timeString = time.value.ToString();
        moneyString = money.value.ToString();

        if (moneyString == "1")
            money_btm.SetActive(true);

        if (timeString == "1")
            time_btm.SetActive(true);
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
        string Money_file = Application.persistentDataPath + "/Money.txt";
        switch (moneyString)
        {
            case "0":
                {
                    money_1_int = 1480;

                    StreamWriter sw = new StreamWriter(Money_file);
                    sw.WriteLine(money_1_int);
                    sw.Close();
                }
                break;

            case "1":
                {
                    string money_input_string = "";
                    money_input_string = money_input.text;

                    StreamWriter sw = new StreamWriter(Money_file);
                    sw.WriteLine(money_input_string);
                    sw.Close();

                    bool success = Int32.TryParse(money_input_string, out money_1_int);
                    if (!success)
                    {
                        Debug.Log("Conversione fallita.");
                    }
                }
                break;
        }      
        Debug.Log(money_1_int);
    }

    private void choice_time()
    {
        string Time_file = Application.persistentDataPath + "/Time.txt";
        switch (moneyString)
        {
            case "0":
                {
                    time_1_int = 6000;

                    StreamWriter sw = new StreamWriter(Time_file);
                    sw.WriteLine(time_1_int);
                    sw.Close();
                }
                break;

            case "1":
                {
                    string time_input_string = "";
                    time_input_string = time_input.text;

                    StreamWriter sw = new StreamWriter(Time_file);
                    sw.WriteLine(time_input_string);
                    sw.Close();

                    bool success = Int32.TryParse(time_input_string, out time_1_int);
                    if (!success)
                    {
                        Debug.Log("Conversione fallita.");
                    }
                }
                break;
        }
        Debug.Log(time_1_int);
    }
}
