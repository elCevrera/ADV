using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
     
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    static int score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public static void ChangeScore()
    {
        score += 1;
        
    }
    void Update(){
        text.text = "X" + score.ToString();
    }
}
