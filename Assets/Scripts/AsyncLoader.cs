using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject menu;

    [SerializeField] private Slider slider;

    public void LoadLevelBtn(string _levelName)
    {
        menu.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadLevelASync(_levelName));
    }

    IEnumerator LoadLevelASync(string _levelToLoad)
    {
        AsyncOperation loadOperator = SceneManager.LoadSceneAsync(_levelToLoad);
        
        while (!loadOperator.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperator.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
    }
}
