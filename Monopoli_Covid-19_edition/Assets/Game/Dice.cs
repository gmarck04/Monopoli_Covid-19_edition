using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides; //prendo lo sprite del dado
    private SpriteRenderer rend;
    private int whosTurn;
    public int numberExtracted;
    public int number;
    public Animator animator;
    public bool allowed = true; //variabile per ruotare dado

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, 2); //scelta turno
        switch (i)
        {
            case 0:
                whosTurn = 1;
                break;
            case 1:
                whosTurn = -1;
                break;
        }
    }

    private void OnMouseDown()
    {
        if (allowed)
        {
            animator.SetTrigger("Roll"); //animazione inizio
            numberExtracted = Random.Range(1, 6); //generazione numero
            new WaitForSeconds(2f);
            animator.SetInteger("Side", numberExtracted); //imposto lato estratto
            Game_Control.MovePlayer(whosTurn);
            whosTurn *= -1; 
        }
        number = Random.Range(1, 6);
    }
}