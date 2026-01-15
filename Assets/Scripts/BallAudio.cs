using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BallAudio : MonoBehaviour
{
    public AudioSource asSounds;

    public AudioClip CollisionSound;
    public AudioClip BallMovingSound;

    public void PlayBallMovingSound()
    {
        asSounds.PlayOneShot(BallMovingSound);
    }

    public void PlayCollisionSound()
    {
        asSounds.PlayOneShot(CollisionSound);
    }


}
