using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    private void Start() 
    {
        Invoke("ToMainMenu",19f);
    }

    private void ToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
