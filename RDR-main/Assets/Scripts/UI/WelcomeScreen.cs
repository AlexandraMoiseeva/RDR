using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;

public class WelcomeScreen : MonoBehaviour
{
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player controls;

    public GameObject loading;
    public GameObject pressButton;
    public Slider loadingBar;

    void Start()
    {
        DataManager.LoadAll();
        controls = ReInput.players.GetPlayer(playerID);
    }

    void Update()
    {
        if (controls.GetAnyButtonDown())
        {
            pressButton.SetActive(false);
            loading.SetActive(true);
            //SceneManager.LoadScene(Scenes.MainMenuScene.ToString());
            StartCoroutine(LoadAsync());
        }
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        while (!asyncLoad.isDone)
        {
            loadingBar.value = asyncLoad.progress;
            yield return null;
        }
    }
}

