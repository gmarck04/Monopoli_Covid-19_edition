using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn;
    public int numberExtracted;
    public Animator animator;
    public bool allowed = true;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, 1);
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
            animator.SetTrigger("Roll");
            numberExtracted = Random.Range(1, 6);
            new WaitForSeconds(2f);
            animator.SetInteger("Side", numberExtracted);
            Game_Control.MovePlayer(whosTurn);
            whosTurn *= -1;
        }
    }
}