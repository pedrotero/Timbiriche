using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public static Square Instance;
    public GameObject Inner;
    public Line[] Edges;
    public List<Line> lines;
    public SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        sp = Inner.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public bool CheckSelf()
    {
        if (CheckLines())
        {
            if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
            {
                sp.sprite = GameManager.Instance.p1Shape;
                sp.color = Color.blue;
                GameManager.Instance.score1++;
            }

            else
            {
                sp.sprite = GameManager.Instance.p2Shape;
                sp.color = Color.red;
                GameManager.Instance.score2++;
            }
            GameManager.Instance.UpdateScore();
            return true;
        }
        else
            return false;
    }

    public void AddLines(int index, int x, int y)
    {
        lines = BoardManager.Instance.Lines;
        Edges= new Line[]{ lines[index], lines[index+BoardManager.Instance.Width-1], lines[BoardManager.Instance.Height * (BoardManager.Instance.Width - 1) + y + index], lines[BoardManager.Instance.Height * (BoardManager.Instance.Width - 1) + y + index+1] };
        for (int i = 0; i < 4; i++)
        {
            Edges[i].AddSquare(this);
        }
    }

    public bool CheckLines()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!Edges[i].colored)
                return false;
        }

        return true;
    }
}
