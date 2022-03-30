using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject Inner;
    public bool colored;
    public Square[] Squares;
    public bool[] s;

    public void Awake()
    {
        s = new bool[2];
        colored = false;
        Squares = new Square[2];
    }



    public void AddSquare(Square s)
    {
        if (Squares[0]==null)
        {
            Squares[0] = s;
        }
        else if (Squares[1]==null)
        {
            Squares[1] = s;
        }

        
    }

    private void OnMouseDown()
    {
        if (!colored)
        {
            colored = true;
            if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
            {
                Inner.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else
            {
                Inner.GetComponent<SpriteRenderer>().color = Color.red;
            }
                
            s[0] = Squares[0].CheckSelf();
            if (Squares[1] != null)
                s[1] = Squares[1].CheckSelf();
            else
                s[1] = false;

            if (!(s[0] || s[1]))
                GameManager.Instance.SwitchPlayer();

        }
        
    }

    private void OnMouseEnter()
    {
        if (!colored)
        {
            Inner.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnMouseExit()
    {
        if (!colored)
        {
            Inner.GetComponent<SpriteRenderer>().color = new Color(0.07f, 0.07f, 0.07f, 0.5f);

        }
    }
}
