using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayButton : MonoBehaviour
{
    public int n=3;
    public int p1 = 0;
    public int p2 = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setN(float value)
    {
        n = (int)value;
    }

    public void setP1(int value)
    {
        p1 = value;
    }

    public void setP2(int value)
    {
        p2 = value;
    }

    public void loadGame()
    {
        PlayerPrefs.SetInt("n", n);
        PlayerPrefs.SetInt("p1Shape", p1);
        PlayerPrefs.SetInt("p2Shape", p2);
        SceneManager.LoadScene("Game");
    }
}
