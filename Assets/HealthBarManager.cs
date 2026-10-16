using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] public Image healthFillImage;
    [SerializeField] private float smoothSpeed = 10f;
    private Stats playerStats;

    private void Start()
    {
        // Find the Stats component where isPlayer = true
        var allStats = FindObjectsOfType<Stats>();

        foreach (var stats in allStats)
        {
            if (stats.isPlayer)
            {
                playerStats = stats;
                break;
            }
        }

        if (playerStats == null)
        {
            Debug.LogError("Player Stats not found!");
        }
    }

    private void Update()
    {
        if (playerStats != null)
        {
            float targetFill = playerStats.GetCurrentHealth() / playerStats.GetMaxHealth();
            healthFillImage.fillAmount = Mathf.Lerp(healthFillImage.fillAmount, targetFill, smoothSpeed * Time.deltaTime);
        }
    }
}

