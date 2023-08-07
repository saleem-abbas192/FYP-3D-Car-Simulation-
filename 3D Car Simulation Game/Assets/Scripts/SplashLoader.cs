using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashLoader : MonoBehaviour
{
    
    void Start()
    {
        Invoke("LoadNextScene", 9f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

}
