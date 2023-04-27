using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject ExitButton;
    
    [Header("Info Section")]
    public GameObject InfoButton;
    public GameObject InfoPanel;
    public GameObject CloseInfoButton;

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay - Stage 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowInfo()
    {
        // InfoPanel.SetActive(true);
        if (InfoPanel.gameObject.activeSelf)
        {
            InfoPanel.SetActive(false);
        }
        else
        {
            InfoPanel.SetActive(true);
        }
    }
}
