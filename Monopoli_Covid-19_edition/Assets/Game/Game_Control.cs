using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Game_Control : MonoBehaviour
{
    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText, Timer;
    private static GameObject player1, player2;
    public GameObject dice;

    private int Money_int_giocatore1 = 1480;
    private int Money_int_giocatore2 = 1480;
    public int Time_int = 6000;

    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gamestarted = false; 


    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Timer");
        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<Follow_the_path>().Move();
        player2.GetComponent<Follow_the_path>().Move();

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);

        string Time_file = Application.persistentDataPath + "/Time.txt";
        string Money_file = Application.persistentDataPath + "/Money.txt";

        if (File.Exists(Money_file))
        {
            var data = File.ReadAllLines(Money_file);
            Debug.Log(data[0]);
            Money_int_giocatore1 = Convert.ToInt32(data[0]);
            Money_int_giocatore2 = Convert.ToInt32(data[0]);
        }

        if (File.Exists(Time_file))
        {
            var data = File.ReadAllLines(Time_file);
            Debug.Log(data[0]);
            Time_int = Convert.ToInt32(data[0]);
        }

        Debug.Log(Time_int);
        Debug.Log(Money_int_giocatore1);
        Debug.Log(Money_int_giocatore2);

        StartCoroutine(StartCountdown());
    }


    
    public IEnumerator StartCountdown()
    {        
        while (Time_int > 0)
        {
            yield return new WaitForSeconds(1.0f);
            Time_int--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        string Time_file = Application.persistentDataPath + "/Time.txt";
        string Money_file = Application.persistentDataPath + "/Money.txt";

        float minutes = Mathf.FloorToInt(Time_int / 60);
        float seconds = Mathf.FloorToInt(Time_int % 60);        
        Timer.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (Money_int_giocatore1 <= 0)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gamestarted = false;
            dice.GetComponent<Dice>().allowed = false;
            if (File.Exists(Money_file))
                File.Delete(Money_file);

            if (File.Exists(Time_file))
                File.Delete(Time_file);
        }

        if (Money_int_giocatore2 <= 0)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gamestarted = false;
            dice.GetComponent<Dice>().allowed = false;
            if (File.Exists(Money_file))
                File.Delete(Money_file);

            if (File.Exists(Time_file))
                File.Delete(Time_file);
        }

        if (Time_int <= 0)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "No Player Wins";
            gamestarted = false;
            dice.GetComponent<Dice>().allowed = false;
            if (File.Exists(Money_file))
                File.Delete(Money_file);

            if (File.Exists(Time_file))
                File.Delete(Time_file);
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove)
        {
            case 1:
                player1.GetComponent<Follow_the_path>().Move();
                gamestarted = true;
                break;
            case -1:
                player2.GetComponent<Follow_the_path>().Move();
                gamestarted = true;
                break;
        }
    }
}
