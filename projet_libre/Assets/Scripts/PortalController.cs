using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{

    private GameObject player;
    public GameObject Portal;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage_1" && player.GetComponent<PlayerStats>().nbkill >= 15)
        {
            Portal.SetActive(true);
        }
        if (sceneName == "Stage_2" && player.GetComponent<PlayerStats>().nbkill >= 20)
        {
            Portal.SetActive(true);
        }
        if (sceneName == "Stage_3" && player.GetComponent<PlayerStats>().nbkill >= 25)
        {
            Portal.SetActive(true);
        }
        if (sceneName == "Stage_Boss" && !GameObject.FindWithTag("Enemy"))
        {
            Portal.SetActive(true);
        }
    }
}
