using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isDashing = false;
    public float currentInput;
    public int id;
    public float moveSpeed = 2f;
    public bool resetPositionsOnGameReset = true;

    private Vector3 startPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null) Debug.LogWarning("Paddle: Rigidbody2D not found on this GameObject.");
        }

        startPosition = transform.position;
        GameManager.instance.onResetGame += ResetPosition;
    }

    private void ResetPosition()
    {
        if (resetPositionsOnGameReset)
        {
        transform.position = startPosition;
        } else
        {
            return;
        }
    }
    private void Update()
    {
        currentInput = ProcessInput(id);
    }

    private void FixedUpdate()
    {
        if(isDashing) return;
        Move(currentInput);
    }

    public float ProcessInput(int playerID)
    {
        float movement = 0f;
        switch (playerID)
        {
            case 1:
                movement = Input.GetAxis("MovePlayer1");
                break;
            
             case 2:
                movement = Input.GetAxis("MovePlayer2");
                break;
            default:
                return 0f;
        }

        return movement;
        
    }

    private void Move( float movement)
    {
        Vector2 velo = rb.linearVelocity;
        velo.y = movement * moveSpeed;
        rb.linearVelocity = velo;

        
    }
   
}
