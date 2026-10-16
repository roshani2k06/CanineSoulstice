using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialPromptManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject promptPanel;
    public TextMeshProUGUI promptTextWD;
    public TextMeshProUGUI promptTextSpace;
    public TextMeshProUGUI promptTextLeftClick;
    public TextMeshProUGUI promptTextShift;
    public TextMeshProUGUI promptTextE;
    public TextMeshProUGUI promptTextWallJump;

    private void Start()
    {
        if (promptPanel != null)
            promptPanel.SetActive(false); // Hide on start
    }

    public void ShowPromptWD(string message)
    {
        if (promptPanel != null && promptTextWD != null)
        {
            promptTextWD.text = message;
            promptPanel.SetActive(true);
        }
    }

    public void ShowPromptE(string message)
    {
        if (promptPanel != null && promptTextE != null)
        {
            promptTextE.text = message;
            promptPanel.SetActive(true);
        }
    }

    public void ShowPromptSpace(string message)
    {
        if (promptPanel != null && promptTextSpace != null)
        {
            promptTextSpace.text = message;
            promptPanel.SetActive(true);
        }
    }

    public void ShowPromptShft(string message)
    {
        if (promptPanel != null && promptTextShift != null)
        {
            promptTextShift.text = message;
            promptPanel.SetActive(true);
        }
    }

    public void ShowPromptAttack(string message)
    {
        if (promptPanel != null && promptTextLeftClick != null)
        {
            promptTextLeftClick.text = message;
            promptPanel.SetActive(true);
        }
    }

    public void ShowPromptWallJump(string message)
    {
        if (promptPanel != null && promptTextWallJump != null)
        {
            promptTextWallJump.text = message;
            promptPanel.SetActive(true);
        }
    }

    public void HidePrompt()
    {
        if (promptPanel != null)
            promptPanel.SetActive(false);
    }
}
