using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private bool hasShield = false;
    private bool canDoubleJump = false;
    private float originalSpeed;
    public float moveSpeed = 5f;
    public float boostedSpeed = 8f;

    public bool magnetActive = false;
    public float attackMultiplier = 1f;

    [Header("Death and Respawn Settings")]
    public float respawnDelay = 2f;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        originalSpeed = moveSpeed;
    }

    private void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            StartCoroutine(HandleDeath());
        }
    }

    #region Health Methods

    public void HealPercent(int percent)
    {
        int healAmount = maxHealth * percent / 100;
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        Debug.Log("Healed: " + healAmount);
    }

    public void FullHeal()
    {
        currentHealth = maxHealth;
        Debug.Log("Fully healed!");
    }

    public void StartRegen(int amountPerSecond, float duration)
    {
        StartCoroutine(RegenCoroutine(amountPerSecond, duration));
    }

    private IEnumerator RegenCoroutine(int amountPerSecond, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            HealPercent(amountPerSecond);
            yield return new WaitForSeconds(1f);
            timer += 1f;
        }
    }

    #endregion

    #region Powerups and Buffs

    public void EnableDoubleJump(float duration)
    {
        StartCoroutine(DoubleJumpCoroutine(duration));
    }

    private IEnumerator DoubleJumpCoroutine(float duration)
    {
        canDoubleJump = true;
        yield return new WaitForSeconds(duration);
        canDoubleJump = false;
    }

    public void BoostSpeed(float duration)
    {
        StartCoroutine(SpeedBoostCoroutine(duration));
    }

    private IEnumerator SpeedBoostCoroutine(float duration)
    {
        moveSpeed = boostedSpeed;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalSpeed;
    }

    public void GiveShield()
    {
        hasShield = true;
        Debug.Log("Shield Activated!");
    }

    public void BoostAttack(float duration)
    {
        StartCoroutine(AttackBoostCoroutine(duration));
    }

    private IEnumerator AttackBoostCoroutine(float duration)
    {
        attackMultiplier = 2f;
        yield return new WaitForSeconds(duration);
        attackMultiplier = 1f;
    }

    public void ActivateMagnet(float duration)
    {
        StartCoroutine(MagnetCoroutine(duration));
    }

    private IEnumerator MagnetCoroutine(float duration)
    {
        magnetActive = true;
        yield return new WaitForSeconds(duration);
        magnetActive = false;
    }

    public void OpenMysteryEgg()
    {
        int randomReward = Random.Range(0, 3);
        switch (randomReward)
        {
            case 0:
                HealPercent(20);
                Debug.Log("Mystery Egg: +20% HP!");
                break;
            case 1:
                BoostSpeed(10f);
                Debug.Log("Mystery Egg: Speed Boost!");
                break;
            case 2:
                // Example: spawn mini-boss
                Debug.Log("Mystery Egg: Mini-boss spawned!");
                break;
        }
    }

    #endregion

    #region Death and Respawn

    private IEnumerator HandleDeath()
    {
        isDead = true;
        Debug.Log("Player Died!");

        // You can trigger death animation here if you want

        yield return new WaitForSeconds(respawnDelay);

        Respawn();
    }

    private void Respawn()
    {
        Vector3 respawnPosition;

        if (CheckpointManager.instance != null && CheckpointManager.instance.GetLastCheckpoint() != Vector2.zero)
        {
            respawnPosition = CheckpointManager.instance.GetLastCheckpoint();
            respawnPosition.y += 1f; // Lift slightly above ground
            Debug.Log("Respawning at checkpoint: " + respawnPosition);
        }
        else
        {
            respawnPosition = transform.position; // If no checkpoint, respawn at current
            respawnPosition.y += 1f;
            Debug.Log("Respawning at current position: " + respawnPosition);
        }

        transform.position = respawnPosition;
        FullHeal(); // Fully heal on respawn
        ResetBuffs(); // Optional: Reset any temporary buffs
        isDead = false;
    }

    private void ResetBuffs()
    {
        // Optional: Reset power-ups
        canDoubleJump = false;
        moveSpeed = originalSpeed;
        attackMultiplier = 1f;
        magnetActive = false;
        hasShield = false;
        Debug.Log("Buffs Reset After Respawn!");
    }

    #endregion
}

