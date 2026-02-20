using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;

    float cooldownTimer;
    float activeTimer;
    float description;

    enum AbilityState { Ready, Active, Cooldown }
    AbilityState abilityState = AbilityState.Ready;

    public KeyCode key; // Checks if the assigned key is pressed to activate the ability

    void Update()
    {
        switch (abilityState)
        {
            case AbilityState.Ready:
                if (Input.GetKeyDown(KeyCode.Space)) // Edit in the future to allow for different input types (buttons, keys, etc.) and to use the undeprecated version of Input.GetAxis
                {
                    Debug.Log("Activating ability: " + ability.name);
                    ability.Activate(gameObject);
                    abilityState = AbilityState.Active;
                    activeTimer = ability.activeTime;
                }
                break;

            case AbilityState.Active:
                activeTimer -= Time.deltaTime;
                if (activeTimer <= 0)
                {
                    Debug.Log("Ability " + ability.name + " has finished its active time.");
                    abilityState = AbilityState.Cooldown;
                    cooldownTimer = ability.cooldownTime;
                }
                break;

            case AbilityState.Cooldown:
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0)
                {
                    Debug.Log("Ability " + ability.name + " is now ready.");
                    abilityState = AbilityState.Ready;
                }
                break;
        }
        // if (Input.GetKeyDown(key))
        // {
        //     ability.Activate();
        // }
    }
}
