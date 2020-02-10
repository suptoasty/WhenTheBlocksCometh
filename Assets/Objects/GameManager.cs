using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText; 
    private int score = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPoint() {
        score++;
        scoreText.text = "Score: "+score;
    }

    public void resetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
