using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleportation : MonoBehaviour
{
    private int sceneNumber;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage_1")
        {
            sceneNumber = 2;
        }
        if (sceneName == "Stage_2")
        {
            sceneNumber = 3;
        }
        if (sceneName == "Stage_3")
        {
            sceneNumber = 4;
        }
        if (sceneName == "Stage_Boss")
        {
            sceneNumber = 5;
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (other.gameObject.name == "Player")
        {
            if (sceneName == "Stage_Boss")
            {
                Timer.timerOn = false;
            }
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
