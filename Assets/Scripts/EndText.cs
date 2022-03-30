using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{
    public Text t;
    public int result;
    // Start is called before the first frame update
    void Start()
    {   result = PlayerPrefs.GetInt("Result");
        switch (result)
        {
            case 0:
                t.text = "Draw :-|";
                break;
            case 1:
                t.text = "Player 1 Wins! :-)";
                break;
            case 2:
                t.text = "Player 2 Wins! :-)";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
