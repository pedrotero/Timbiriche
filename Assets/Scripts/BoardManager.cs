using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public int Width;
    public int Height;
    public Point PointPrefab;
    public Line LinePrefab;
    public Square SquarePrefab;
    public List<Line> Lines = new List<Line>();
    public Camera cam;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Width = PlayerPrefs.GetInt("n");
        Height = PlayerPrefs.GetInt("n");
        GenerateBoard();
        cam.orthographicSize = 2+(Width-3)/2;
    }

    private void GenerateBoard()
    {

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width-1; j++)
            {
                Lines.Add(Instantiate(LinePrefab, new Vector3(j+0.5f, i,1), Quaternion.Euler(0f, 0f, 90f)));
            }
        }

        for (int i = 0; i < Height-1; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Lines.Add(Instantiate(LinePrefab, new Vector3(j, i + 0.5f, 1), Quaternion.identity));
            }
        }


        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {

                Instantiate(PointPrefab, new Vector2(i, j), Quaternion.identity);
            }
        }
        int c = 0;
        for (int i = 0; i < Height-1; i++)
        {
            for (int j = 0; j < Width-1; j++)
            {

                Square temp = Instantiate(SquarePrefab, new Vector2(j+0.5f, i+0.5f), Quaternion.identity);
                temp.AddLines(c,j,i);
                c++;
            }
        }


        var center = new Vector2((float)Height / 2 - 0.5f, (float)Width / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
