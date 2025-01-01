using UnityEngine;
using TMPro;

public class ballScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed;

    public TextMeshProUGUI playerOneScoreText;  //these references dont work because they need to be attached to an empty object (UI) with a seperate code.
    public TextMeshProUGUI playerTwoScoreText;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;


    void Start()
    {
        bool isRight = UnityEngine.Random.value >= 0.5;

        float xVelocity = -1f;

        if (isRight == true)
        {
            xVelocity = 1f;
        }

        float yVelocity = UnityEngine.Random.Range(-1,1);

        rb.velocity = new Vector2 (xVelocity * startingSpeed, yVelocity * startingSpeed);
    }

    public void resetBall()
    {
        rb.velocity = Vector2.zero;

        transform.position = Vector2.zero;

        Invoke(nameof(relaunchBall), 1f);
    }

    public void relaunchBall()
    {
        bool isRight = UnityEngine.Random.value >= 0.5;

        float xVelocity = isRight ? 1f : -1f;
        float yVelocity = UnityEngine.Random.Range(-1f, 1f);

        rb.velocity = new Vector2 (xVelocity * startingSpeed, yVelocity * startingSpeed);
    }

    void Update()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));

        if (transform.position.x > screenBounds.x)      //first player scores
        {
            playerOneScore++;

            playerOneScoreText.text = playerOneScore.ToString();

            resetBall();
        }

        if (transform.position.x < -screenBounds.x)     //second player scores
        {
            playerTwoScore++;

            playerTwoScoreText.text = playerTwoScore.ToString();

            resetBall ();
        }

    }
}
