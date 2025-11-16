using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Header("Assign the enemy GameObjects here")]
    public GameObject[] enemies;

    [Header("Name of the scene to load")]
    public string nextSceneName;

    void Update()
    {
        int deadCount = 0;

        // Count how many enemies are destroyed
        foreach (var enemy in enemies)
        {
            if (enemy == null)
            {
                deadCount++;
            }
        }

        // If 2 or more enemies are dead → change scene
        if (deadCount >= 2)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}