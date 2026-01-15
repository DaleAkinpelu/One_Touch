using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
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
        float movement = ProcessInput();
        Move(movement);
    }

    private float ProcessInput()
    {
        float movement = 0f;
        switch (id)
        {
            case 1:
                movement = Input.GetAxis("MovePlayer1");
                break;
            
             case 2:
                movement = Input.GetAxis("MovePlayer2");
                break;
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
