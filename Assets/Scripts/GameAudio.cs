using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameAudio : MonoBehaviour
{
    public AudioSource asSounds;

    public AudioClip WalkingSound;
    public AudioClip PowerUpSound;
    public AudioClip ScoreSound;
    public AudioClip WinSound;
    public AudioClip StartGameSound;
    public AudioClip CollisionSound;
    public AudioClip BallMovingSound;
    public AudioClip backgroundMusic;

    public void PlayCollisionSound()
    {
        asSounds.PlayOneShot(CollisionSound);
    }
    
    public void PlayWalkingSound()
    {
        asSounds.PlayOneShot(WalkingSound);
    }

    public void PlayPowerUpSound()
    {
        asSounds.PlayOneShot(PowerUpSound);
    }

    public void PlayScoreSound()
    {
        asSounds.PlayOneShot(ScoreSound);
    }

    public void PlayWinSound()
    {
        asSounds.PlayOneShot(WinSound);
    }

    public void PlayStartGameSound()
    {
        asSounds.PlayOneShot(StartGameSound);
    }
    public void PlayBallMovingSound()
    {
        asSounds.PlayOneShot(BallMovingSound);
    }

    // public void PlayBackgroundMusic()
    // {
    //     asSounds.clip = backgroundMusic;
    //     asSounds.loop = true;
    //     asSounds.Play();
    // }
}
