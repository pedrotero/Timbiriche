using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void LoadStart()
    {
        PlayerPrefs.SetInt("n", 3);
        PlayerPrefs.SetInt("p1Shape", 0);
        PlayerPrefs.SetInt("p2Shape", 0);
        PlayerPrefs.SetInt("Result", 0);
        SceneManager.LoadScene("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
