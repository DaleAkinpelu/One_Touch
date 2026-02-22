using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Scriptable Objects/Dash")]
public class Dash : Ability
{
    public float dashVelocity;


    // Update is called once per frame
    public override void Activate(GameObject parent)
    {
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>(); 
        Player player = parent.GetComponent<Player>();
        
        float input = player.currentInput;

        if (input == 0) return; // If there is no input, do not activate the dash

        player.isDashing = true; // Set the isDashing flag to true to indicate that the player is currently dashing

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, input * dashVelocity); // Set the velocity to the direction of movement multiplied by the dash velocity
        Debug.Log("Ability Activated: " + name + " with velocity " + dashVelocity);

        player.StartCoroutine(EndDash(player)); // Start a coroutine to end the dash after the active time has elapsed
    }

    private IEnumerator EndDash(Player player)
{
    yield return new WaitForSeconds(activeTime);
    player.isDashing = false;
}
}
