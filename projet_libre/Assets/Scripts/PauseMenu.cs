using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    // Start is called before the first frame update
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(PauseMenuUI.activeInHierarchy == true)
            {
                Timer.timerOn = true;
                PauseMenuUI.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
            else
            {
                Timer.timerOn = false;
                PauseMenuUI.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        Timer.timerOn = true;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }


}
