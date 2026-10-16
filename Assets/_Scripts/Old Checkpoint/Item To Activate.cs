using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool playerInRange = false;
    private Animator campfireAnim;

    private PlayerHealthBar playerHealthBar;
    private Transform playerTransform;

    private bool isCurrentCheckpoint = false; // NEW

    void Start()
    {
        campfireAnim = GetComponent<Animator>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            playerHealthBar = FindObjectOfType<PlayerHealthBar>();
        }
        else
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ActivateCheckpoint();
        }

        // Only the current checkpoint handles respawn
        if (isCurrentCheckpoint && playerHealthBar != null && playerHealthBar.healthFillImage.fillAmount <= 0f)
        {
            RespawnPlayer();
        }
    }

    void ActivateCheckpoint()
    {
        if (CheckpointManager.instance != null)
        {
            CheckpointManager.instance.SetCheckpoint(transform.position * new Vector2(1, 10));
            MakeThisTheCurrentCheckpoint();

            if (campfireAnim != null)
            {
                campfireAnim.SetTrigger("isActivated");
            }

            Debug.Log("Checkpoint activated at: " + transform.position);
        }
    }

    void RespawnPlayer()
    {
        if (CheckpointManager.instance != null && playerTransform != null)
        {
            Vector2 checkpointPosition = CheckpointManager.instance.GetLastCheckpoint();
            playerTransform.position = checkpointPosition;
            transform.parent.gameObject.SetActive(true);
            Debug.Log("Player respawned at: " + checkpointPosition);

            Core core = playerTransform.GetComponentInChildren<Core>();
            if (core != null)
            {
                Stats stats = core.GetCoreComponent<Stats>();
                if (stats != null)
                {
                    stats.IncreaseHealth(9999); // Fully heal
                }
            }
        }
    }

    private void MakeThisTheCurrentCheckpoint()
    {
        foreach (var checkpoint in FindObjectsOfType<Item>())
        {
            checkpoint.isCurrentCheckpoint = false;
        }
        isCurrentCheckpoint = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}





