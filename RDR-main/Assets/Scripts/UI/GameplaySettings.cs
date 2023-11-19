using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplaySettings : MonoBehaviour
{
    public SliderSync musicVolume_slider, effectVolume_slider, forceMultiplier_slider, massMultiplier_slider;
    
    private float volume_K = 0.01f;

    void Awake()
    {
    }

    private void Start()
    {
        SendOldDataToUI();
    }

    void Update()
    {
        Parameters.musicVolume = musicVolume_slider.GetValue() * volume_K;
        Parameters.effectVolume = effectVolume_slider.GetValue() * volume_K;
    }
    private void SendOldDataToUI()
    {
        forceMultiplier_slider.SetValue(Parameters.forceMultiplier);
        massMultiplier_slider.SetValue(Parameters.massMultiplier);
        musicVolume_slider.SetValue(Parameters.musicVolume / volume_K);
        effectVolume_slider.SetValue(Parameters.effectVolume / volume_K);
    }

    public void ControlSetUp()
    {
        Parameters.forceMultiplier = forceMultiplier_slider.GetValue();
        Parameters.massMultiplier = massMultiplier_slider.GetValue();
        DataManager.SaveAll();

        SceneManager.LoadScene(Scenes.ControlMapperScene.ToString());
    }
    public void Apply()
    {
        Parameters.forceMultiplier = forceMultiplier_slider.GetValue();
        Parameters.massMultiplier = massMultiplier_slider.GetValue();
        DataManager.SaveAll();
    }
}
