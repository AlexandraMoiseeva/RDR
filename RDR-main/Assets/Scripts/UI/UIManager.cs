using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;

public class UIManager : MonoBehaviour
{
    public MenuPanelComponent pauseMenu;
    public MenuPanelComponent playerUI;
    public Text speedValue;
    public Text flyModeValue;

    public Text raceTime;
    public Text lapTime;

    float raceTimeValue;
    float lapTimeValue;

    public Text lapNumberValue;
    public Text crashNumberValue;

    bool isPaused;

    void Start()
    {
        SetPlayerUI();
    }

    void Update()
    {
        raceTimeValue += Time.deltaTime;
        lapTimeValue += Time.deltaTime;
        raceTime.text = raceTimeValue.ToString();
        lapTime.text = lapTimeValue.ToString();

    }
    void UpdateData()
    {
        //pauseMenu.transform.Find("Quad Panel").GetComponent<QuadSettings>().LoadData();
    }

    public void ShowInfo(int speed, FlyMode flymode, int lapNumber, int crashNumber)
    {
        SetSpeed(speed);
        SetFlyMode(flymode);

        lapNumberValue.text = lapNumber.ToString();
        crashNumberValue.text = crashNumber.ToString();
    }

    private void SetSpeed(int speed)
    {
        speedValue.text = speed.ToString() + " ÊÌ/×";
    }
    private void SetFlyMode(FlyMode fm)
    {
        string str = "";
        switch (fm)
        {
            case FlyMode.Arm: str = "ARM"; flyModeValue.color = Color.red; break;
            case FlyMode.Acro: str = "Acro"; flyModeValue.color = Color.yellow; break;
            case FlyMode.Stab: str = "Stable"; flyModeValue.color = Color.green; break;
            default: break;
        }
        flyModeValue.text = str;
    }

    public void ChangeUI()
    {
        UpdateData();
        if (isPaused)
        {
            SetPlayerUI();
        }
        else
        {
            SetPauseUI();
        }
        isPaused = !isPaused;
    }

    public void SetUI(string UIName)
    {
        switch (UIName)
        {
            case "Pause":
                SetPauseUI();
                break;
            case "Player":
                SetPlayerUI();
                break;
            default:
                SetPlayerUI();
                break;
        }
    }

    private void SetPlayerUI()
    {
        Time.timeScale = 1;
        playerUI.Show();
        pauseMenu.Hide();
    }
    private void SetPauseUI()
    {
        Time.timeScale = 0;
        playerUI.Hide();
        pauseMenu.Show();
    }

    public void PressRespawn(Quad quadScript)
    {
        ChangeUI();
        quadScript.Respawn();
    }

    public void PressExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Scenes.MainMenuScene.ToString());
    }
}
