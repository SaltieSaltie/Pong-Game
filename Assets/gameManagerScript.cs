using TMPro;
using UnityEngine;

public class gameManagerScript : MonoBehaviour
{
    public GameObject ball;

    private Vector2 ballPosition;

    public TextMeshProUGUI playerOneScoreText; 
    public TextMeshProUGUI playerTwoScoreText;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;

    void Start()
    {

    }

    void Update()
    {
        ballPosition = ball.transform.position;

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if (ball.transform.position.x > screenBounds.x)      //first player scores
        {
            playerOneScore++;

            playerOneScoreText.text = playerOneScore.ToString();
        }

        if (ball.transform.position.x < -screenBounds.x)     //second player scores
        {
            playerTwoScore++;

            playerTwoScoreText.text = playerTwoScore.ToString();
        }

        if (Input.GetKey(KeyCode.R))    //Reset the score.  
        {
            playerOneScore = 0;
            playerTwoScore = 0;

            playerOneScoreText.text = 0.ToString();
            playerTwoScoreText.text = 0.ToString();
        }

        if (Input.GetKey(KeyCode.Escape))   //Quit the game.
        {
            Application.Quit();
        }

    }
}
