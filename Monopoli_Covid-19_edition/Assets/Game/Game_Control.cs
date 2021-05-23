using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Game_Control : MonoBehaviour
{
    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText, Timer, soldiPlayer1, soldiPlayer2; //inizializzo i GameObject
    private static GameObject player1, player2;
    public GameObject dice; //prendo il GameObject dice da Dice (elemento)
    private int Money_int_giocatore1 = 1480;
    private int Money_int_giocatore2 = 1480;
    public int Time_int = 6000;

    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gamestarted = false; //variabile gioco, comincia o termina


    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Timer"); //cerco l'elemento Timer e lo inserisco nel GameObject Timer
        whoWinsTextShadow = GameObject.Find("WhoWinsText"); //cerco l'elemento WhoWinsText e lo inserisco nel GameObject whoWinsTextShadow
        player1MoveText = GameObject.Find("Player1MoveText"); //cerco l'elemento Player1MoveText e lo inserisco nel GameObject player1MoveText
        player2MoveText = GameObject.Find("Player2MoveText"); //cerco l'elemento Player2MoveText e lo inserisco nel GameObject player2MoveText
        soldiPlayer1 = GameObject.Find("SoldiPlayer1"); //cerco l'elemento SoldiPlayer1 e lo inserisco nel GameObject soldiPlayer1
        soldiPlayer2 = GameObject.Find("SoldiPlayer2"); //cerco l'elemento SoldiPlayer2 e lo inserisco nel GameObject soldiPlayer2
        player1 = GameObject.Find("Player1"); // cerco l'elemento Player1 e lo inserisco nel GameObject player1
        player2 = GameObject.Find("Player2"); //cerco l'elemento Player2 e lo inserisco nel GameObject player2

        player1.GetComponent<Follow_the_path>().Move(); //chiamo la funzione move dal codice Follow_the_path
        player2.GetComponent<Follow_the_path>().Move();

        whoWinsTextShadow.gameObject.SetActive(false); //imposto false
        player1MoveText.gameObject.SetActive(true); //imposto true
        player2MoveText.gameObject.SetActive(false); //imposto false

        string Time_file = Application.persistentDataPath + "/Time.txt"; //percorso file Time.txt
        string Money_file = Application.persistentDataPath + "/Money.txt"; //percorso file Money.txt

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
        string Time_file = Application.persistentDataPath + "/Time.txt"; //percorso file Time.txt
        string Money_file = Application.persistentDataPath + "/Money.txt"; //percorso file Money.txt

        float minutes = Mathf.FloorToInt(Time_int / 60); //fuzione timer
        float seconds = Mathf.FloorToInt(Time_int % 60);        
        Timer.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);

        soldiPlayer1.GetComponent<Text>().text = Convert.ToString(Money_int_giocatore1); //funzione soldi a schermo
        soldiPlayer2.GetComponent<Text>().text = Convert.ToString(Money_int_giocatore2);

        if (Money_int_giocatore2 <= 0) //caso vittoria giocatore 1 
        {
            whoWinsTextShadow.gameObject.SetActive(true); //abilito testo vittoria
            whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins"; //il testo viene modificato
            gamestarted = false; //stop gioco
            dice.GetComponent<Dice>().allowed = false; //il dado si disattiva
            if (File.Exists(Money_file)) //distruzione file se esistono
                File.Delete(Money_file);

            if (File.Exists(Time_file))
                File.Delete(Time_file);
        }

        if (Money_int_giocatore1 <= 0) //caso vittoria giocatore 2
        {
            whoWinsTextShadow.gameObject.SetActive(true); //abilito testo vittoria
            whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins"; //il testo viene modificato
            gamestarted = false; //stop gioco
            dice.GetComponent<Dice>().allowed = false; //il dado si disattiva
            if (File.Exists(Money_file)) //distruzione file se esistono
                File.Delete(Money_file);

            if (File.Exists(Time_file))
                File.Delete(Time_file);
        }

        if (Time_int <= 0)
        {
            whoWinsTextShadow.gameObject.SetActive(true); //abilito testo vittoria
            whoWinsTextShadow.GetComponent<Text>().text = "No Player Wins"; //il testo viene modificato
            gamestarted = false; //stop gioco
            dice.GetComponent<Dice>().allowed = false; //il dado si disattiva
            if (File.Exists(Money_file)) //distruzione file se esistono
                File.Delete(Money_file);

            if (File.Exists(Time_file))
                File.Delete(Time_file);
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) //swich turno
        {
            case 1:
                {
                    player1.GetComponent<Follow_the_path>().Move();
                    gamestarted = true; //gioco inizia  
                    player1MoveText.gameObject.SetActive(false); //disattivazione frase your turn (1)
                    player2MoveText.gameObject.SetActive(true); //attivazione frase your turn (2)
                }
                break;
            case -1:
                {
                    player2.GetComponent<Follow_the_path>().Move();
                    gamestarted = true; //gioco inizia                     
                    player1MoveText.gameObject.SetActive(true); //attivazione frase your turn (1)
                    player2MoveText.gameObject.SetActive(false); //disattivazione frase your turn (2)
                }
                break;
        }
    }
}
