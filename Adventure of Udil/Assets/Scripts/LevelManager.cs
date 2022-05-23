using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Restart()
    {   
        // Restart scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}