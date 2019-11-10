using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public GameObject collectiblesUI;
    public GameObject healthUI;
    [SerializeField]
    private Text scoreText;
    public GameObject settingsMenuUI;
    public GameObject controlsMenuUI;
    public GameObject keyBind;

    // Update is called once per frame
    void Update()
    {
        if (!gameOverUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    if (pauseMenuUI.activeSelf)
                    {
                        Resume();
                    }
                    else if (settingsMenuUI.activeSelf)
                    {
                        settingsMenuUI.SetActive(false);
                        pauseMenuUI.SetActive(true);
                    }
                    else if (controlsMenuUI.activeSelf)
                    {
                        keyBind.GetComponent<KeyBind>().SaveControls();
                        controlsMenuUI.SetActive(false);
                        settingsMenuUI.SetActive(true);
                    }
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        collectiblesUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        collectiblesUI.SetActive(false);
        scoreText.text = string.Format("Счет: {0}", GameMaster.Gm.Score);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
