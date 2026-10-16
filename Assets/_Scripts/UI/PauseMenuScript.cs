using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool ispaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
            {
                Resumegame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }

    public void Resumegame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }

    public void OnMainMenuPressed()
    {
        SceneManager.LoadScene(0);
    }

}
