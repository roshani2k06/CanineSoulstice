using UnityEngine;

public class SecretManager : MonoBehaviour
{
    public static SecretManager Instance;

    private int hiddenGemsFound = 0;
    private bool goldenKeyFound = false;  // Track if the Golden Key is collected

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void CollectSecret(string secretType)
    {
        if (secretType == "HiddenGem")
        {
            hiddenGemsFound++;
            Debug.Log("Hidden Gem found! Total: " + hiddenGemsFound);
        }
        else if (secretType == "GoldenKey")
        {
            goldenKeyFound = true;
            Debug.Log("Golden Key collected!");
        }
    }

    // Method to check if the player has the Golden Key
    public bool HasGoldenKey()
    {
        return goldenKeyFound;
    }
}




