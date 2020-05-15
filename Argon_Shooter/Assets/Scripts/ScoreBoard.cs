using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;

    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>(); //scoretext
        scoreText.text = "Score: \n" +score.ToString();
    }
    
    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        scoreText.text = "Score: \n" + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
