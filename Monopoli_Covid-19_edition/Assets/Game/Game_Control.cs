using UnityEngine;
using UnityEngine.UI;

public class Game_Control : MonoBehaviour
{
    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;
    private GameObject Money;
    private GameObject Time;
    private static GameObject player1, player2;

    private int Money_int_giocatore1 = 0;
    private int Money_int_giocatore2 = 0;
    private int Time_int = 0;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gamestarted = false;

    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
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

        //Money_int_giocatore1 = Money.GetComponent<Valori>().money_int;
        //Money_int_giocatore2 = Money.GetComponent<Valori>().money_int;
        //Time_int = Money.GetComponent<Valori>().time_int;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Money_int_giocatore1 == 0)
        //{
        //    whoWinsTextShadow.gameObject.SetActive(true);
        //    whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
        //    gameOver = true;
        //}

        //if (Money_int_giocatore2 == 0)
        //{
        //    whoWinsTextShadow.gameObject.SetActive(true);
        //    whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
        //    gameOver = true;
        //}

        //if (Time_int == 0)
        //{
        //    whoWinsTextShadow.gameObject.SetActive(true);
        //    whoWinsTextShadow.GetComponent<Text>().text = "Player N Wins";
        //    gameOver = true;
        //}

        //if (player1.GetComponent<Follow_the_path>().waypointIndex >
        //    player1StartWaypoint + diceSideThrown)
        //{
        //    player1.GetComponent<Follow_the_path>().Move();
        //    player1MoveText.gameObject.SetActive(false);
        //    player2MoveText.gameObject.SetActive(true);
        //    player1StartWaypoint = player1.GetComponent<Follow_the_path>().waypointIndex - 1;
        //}

        //if (player2.GetComponent<Follow_the_path>().waypointIndex >
        //    player2StartWaypoint + diceSideThrown)
        //{
        //    player2.GetComponent<Follow_the_path>().Move();
        //    player1MoveText.gameObject.SetActive(true);
        //    player2MoveText.gameObject.SetActive(false);
        //    player2StartWaypoint = player2.GetComponent<Follow_the_path>().waypointIndex - 1;
        //}

        //if (player1.GetComponent<Follow_the_path>().waypointIndex ==
        //    player1StartWaypoint + diceSideThrown && gamestarted == true)
        //{
        //    whoWinsTextShadow.gameObject.SetActive(true);
        //    whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
        //    gameOver = true;
        //}

        //if (player2.GetComponent<Follow_the_path>().waypointIndex ==
        //    player2StartWaypoint + diceSideThrown && gamestarted == true)
        //{
        //    whoWinsTextShadow.gameObject.SetActive(true);
        //    player1MoveText.gameObject.SetActive(false);
        //    player2MoveText.gameObject.SetActive(false);
        //    whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
        //    gameOver = true;
        //}
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
