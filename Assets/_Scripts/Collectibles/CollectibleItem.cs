using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum CollectibleType
    {
        SmallHealthPotion,
        LargeHealthKit,
        RegenerationBoost,
        DoubleJumpPowerup,
        SpeedBoost,
        Shield,
        AttackPowerBoost,
        MagnetPowerup,
        HiddenGem,
        GoldenKey,
        MysteryEgg
    }

    public CollectibleType itemType;
    public int healthAmount = 20; // default heal for SmallHealthPotion
    public float buffDuration = 10f; // duration for temporary powerups
    public int regenAmountPerSecond = 5;
    public float regenDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                switch (itemType)
                {
                    case CollectibleType.SmallHealthPotion:
                        player.HealPercent(10); // Heal 10% of max HP
                        break;
                    case CollectibleType.LargeHealthKit:
                        player.FullHeal();
                        break;
                    case CollectibleType.RegenerationBoost:
                        player.StartRegen(regenAmountPerSecond, regenDuration);
                        break;
                    case CollectibleType.DoubleJumpPowerup:
                        player.EnableDoubleJump(buffDuration);
                        break;
                    case CollectibleType.SpeedBoost:
                        player.BoostSpeed(buffDuration);
                        break;
                    case CollectibleType.Shield:
                        player.GiveShield();
                        break;
                    case CollectibleType.AttackPowerBoost:
                        player.BoostAttack(buffDuration);
                        break;
                    case CollectibleType.MagnetPowerup:
                        player.ActivateMagnet(buffDuration);
                        break;
                    case CollectibleType.HiddenGem:
                        SecretManager.Instance.CollectSecret("HiddenGem");
                        break;
                    case CollectibleType.GoldenKey:
                        SecretManager.Instance.CollectSecret("GoldenKey");
                        break;
                    case CollectibleType.MysteryEgg:
                        player.OpenMysteryEgg();
                        break;
                }
            }

            Destroy(gameObject); // Destroy pickup after collection
        }
    }
}


