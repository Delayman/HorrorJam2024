using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickEndGame()
    {
        Debug.Log("Boo!");
        // SceneManager.LoadScene("GameScene");
    }
}
