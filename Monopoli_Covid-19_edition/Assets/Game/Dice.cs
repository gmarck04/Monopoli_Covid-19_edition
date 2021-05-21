using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn;
    public int numberExtracted;
    public Animator animator;

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
        //rend = GetComponent<SpriteRenderer>();
        //for (int i = 0; i < 5; i++)
        //{
        //    diceSides[i] = Resources.Load<Sprite>("DiceSides/");
        //}        
        //rend.sprite = diceSides[5];
    }

    private void OnMouseDown()
    {
        animator.SetTrigger("Roll");
        numberExtracted = Random.Range(1, 6);
        new WaitForSeconds(2f);
        animator.SetInteger("Side", numberExtracted);
        Game_Control.MovePlayer(whosTurn);
        whosTurn *= -1;
        //if (!Game_Control.gameOver && courotineAllowed)
        //{
        //    courotineAllowed = false;
        //    int randomDiceSide = 0;

        //    for (int i = 0; i <= 20; i++)
        //    {
        //        randomDiceSide = Random.Range(0, 6);
        //        //rend.sprite = diceSides[randomDiceSide];
        //        //yield return new WaitForSeconds(0.05f);
        //    }

        //    Game_Control.diceSideThrown = randomDiceSide + 1;
        //    if (whosTurn == 1)
        //    {
        //        Game_Control.MovePlayer(1);
        //    }
        //    else if (whosTurn == -1)
        //    {
        //        Game_Control.MovePlayer(2);
        //    }
        //    //whosTurn *= -1;

        //    courotineAllowed = true;

        //}
    }
}



/*    private int whosTurn = 1;
    private bool courotineAllowed = true;


    public void dado()
    {
        courotineAllowed = false;
        int randomDiceSide = 0;
        //for (int i = 0; i <= 20; i++)
        //{
            
        //}
        randomDiceSide = Random.Range(0, 6);


        Game_Control.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1)
        {
            Game_Control.MovePlayer(1);
        }
        else if (whosTurn == 2)
        {
            Game_Control.MovePlayer(2);
        }
        whosTurn *= -1;
        courotineAllowed = true;
    }
    
}*/
