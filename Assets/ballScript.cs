using UnityEngine;

public class ballScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed;
    public float speedMultiplier;
    public float maxSpeed;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("paddle"))
        {
            rb.velocity *= speedMultiplier;

            rb.velocity = rb.velocity.normalized * rb.velocity.magnitude;

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }

    void Update()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));

        if (transform.position.x > screenBounds.x)      //first player scores
        {
            resetBall();
        }

        if (transform.position.x < -screenBounds.x)     //second player scores
        {
            resetBall ();
        }
    }
}
