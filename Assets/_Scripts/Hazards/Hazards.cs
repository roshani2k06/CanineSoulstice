using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the Core component first
            Core core = collision.gameObject.GetComponentInChildren<Core>();

            if (core != null)
            {
                Stats playerStats = core.GetCoreComponent<Stats>();

                if (playerStats != null)
                {
                    playerStats.DecreaseHealth(playerStats.GetCurrentHealth()); // Instantly drop health to 0
                    Debug.Log("Player touched hazard and died!");
                }
                else
                {
                    Debug.LogError("Stats component not found on Player's Core!");
                }
            }
            else
            {
                Debug.LogError("Core component not found on Player!");
            }
        }
    }
}


