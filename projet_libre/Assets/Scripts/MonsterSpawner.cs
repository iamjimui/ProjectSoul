using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonsterSpawner : MonoBehaviour
{
    public GameObject theEnemy;
    private int enemyCount;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "ProjectSouls")
        {
            enemyCount = 5;
        }
        if (sceneName == "Stage_1")
        {
            enemyCount = 15;
        }
        if (sceneName == "Stage_2")
        {
            enemyCount = 10;
        }
        if (sceneName == "Stage_3")
        {
            enemyCount = 24;
        }
        if (sceneName == "Stage_Boss")
        {
            enemyCount = 1;
        }
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (i < enemyCount)
        {
            Instantiate(theEnemy, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            i += 1;
        }
    }
}
