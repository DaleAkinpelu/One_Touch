using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2f;
    public float maxInitialAngle = 0.6f;
    public float maxInitialY = 4f;
    public float speedMultiplier = 1.1f;

    public bool startFromCenter = true;

    private Vector3 startPosition; 

    public float startX = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // if (rb == null)
        // {
        //     rb = GetComponent<Rigidbody2D>();
        //     if (rb == null) Debug.LogWarning("Football: Rigidbody2D not found on this GameObject.");
        // }
        // if (gameManager == null)
        // {
        //     gameManager = FindFirstObjectByType<GameManager>();
        //     if (gameManager == null) Debug.LogWarning("Football: GameManager not assigned and none found in scene.");
        // }

        GameManager.instance.onResetGame += ResetBall;
        GameManager.instance.gameUI.onStartGame += ResetBall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the football collides with a paddle, log the event, then increase speed
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if (paddle){
            Debug.Log("Football: Collided with Paddle " + paddle.id);
             
            rb.linearVelocity *= speedMultiplier;
        }
        

        // Increase speed by 10% on each collision
        if (rb != null)
        {
            
            rb.linearVelocity *= speedMultiplier;
        
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb != null){
                
                rb.linearVelocity *= speedMultiplier;
                   
            }
            else Debug.LogWarning("Football: Rigidbody2D is null in OnCollisionEnter2D.");
        }
    }

    private float GetSpeed()
    {
        Vector2 currentVelo = rb.linearVelocity;
        float currentSpeed = currentVelo.magnitude;

        return currentSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone)
        {
            
        Debug.Log("Goal Scored!");
        GameManager.instance.OnScoreZoneReached(scoreZone.id);
        // // if (GameManager != null)
        // // {
        // // }
        // // else
        // // {
        // //     Debug.LogWarning($"Football: gameManager is null. Cannot notify score zone {scoreZone.id}.");
        // // }

        // StartCoroutine(Delay());
        
        // Reset position and speed when entering a goal area
        }
    }

    private void ResetBall()
    {
        ResetBallPosition();
        InitialPush();
    }

    private void ResetBallPosition()
    {
        float posY;

        if(startFromCenter){
            posY = 0f;
        } else{
            posY = Random.Range(-maxInitialY, maxInitialY);
        }
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;
            else Debug.LogWarning("Football: Rigidbody2D is null in ResetBall.");
        }
    }

    private void InitialPush()
    {
        Vector2 initialDirection = Random.value < 0.5f ? Vector2.left : Vector2.right;
        initialDirection.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        if (rb != null)
        {
            rb.linearVelocity = initialDirection * speed;
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = initialDirection * speed;
            else Debug.LogWarning("Football: Rigidbody2D is null in InitialPush.");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
    }
}
