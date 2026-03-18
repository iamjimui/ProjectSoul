using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   public void PlayGame()
   {
        Timer.timer = 0;
        PlayerStats.currentRage = 0;
        Timer.timerOn = true;
        SceneManager.LoadScene(1);
   }

   public void QuitGame()
   {
        Debug.Log("Quit");
        Application.Quit(); 
   }

   public void ResetGame()
   {
        Timer.timer = 0;
        PlayerStats.currentRage = 0;
        SceneManager.LoadScene(1);
   }
}
