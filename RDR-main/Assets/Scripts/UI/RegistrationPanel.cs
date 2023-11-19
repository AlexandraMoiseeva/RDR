using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class RegistrationPanel : MonoBehaviour
{
    public TMP_InputField userEmailEnter;
    public TMP_InputField userPasswordEnter;

    public TMP_InputField userNameLogin;
    public TMP_InputField userEmailLogin;
    public TMP_InputField userPasswordLogin;

    public GameObject loadSceen;
    public Image loading;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = userNameLogin.text,
            Email = userEmailLogin.text,
            Password = userPasswordLogin.text,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucces, OnError);
    }

    public void LoginUser()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = userEmailEnter.text,
            Password = userPasswordEnter.text,

            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucces, OnError);
    }

    void OnRegisterSucces(RegisterPlayFabUserResult result)
    {
        print("success");
    }

    void OnLoginSucces(LoginResult result)
    {
        string name = null;
        name = result.InfoResultPayload.PlayerProfile.DisplayName;
        DataManager.displayName = name;

        loadSceen.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    void OnError(PlayFabError Error)
    {
        print(Error);
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Scenes.MainMenuScene.ToString());
        while (!asyncLoad.isDone)
        {
            loading.fillAmount = asyncLoad.progress;
            yield return null;
        }
    }
}
