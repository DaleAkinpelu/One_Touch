using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{ 
    public BallAudio ballAudio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // When the football collides with a paddle, log the event, then increase speed
        Football football= collision.collider.GetComponent<Football>();
        if (football){
            // Play Audio Clip on Collision
            ballAudio.PlayCollisionSound();
        }
        

        
        
    }

}
