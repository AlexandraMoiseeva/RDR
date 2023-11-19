using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuadSettings : MonoBehaviour
{
    public MenuQuad menuQuad;

    SliderSync pitch_P_slider, pitch_I_slider, pitch_D_slider,
                yaw_P_slider, yaw_I_slider, yaw_D_slider,
                roll_P_slider, roll_I_slider, roll_D_slider;
                

    private void Awake()
    {
        GetSlyders();
    }

    private void Start()
    {
        SendOldDataToUI();
    }

    private void Update()
    {
 
    }

    private void GetSlyders()
    {
        pitch_P_slider = this.transform.Find("Display").Find("Pitch").Find("P").GetComponent<SliderSync>();
        pitch_I_slider = this.transform.Find("Display").Find("Pitch").Find("I").GetComponent<SliderSync>();
        pitch_D_slider = this.transform.Find("Display").Find("Pitch").Find("D").GetComponent<SliderSync>();

        yaw_P_slider = this.transform.Find("Display").Find("Yaw").Find("P").GetComponent<SliderSync>();
        yaw_I_slider = this.transform.Find("Display").Find("Yaw").Find("I").GetComponent<SliderSync>();
        yaw_D_slider = this.transform.Find("Display").Find("Yaw").Find("D").GetComponent<SliderSync>();

        roll_P_slider = this.transform.Find("Display").Find("Roll").Find("P").GetComponent<SliderSync>();
        roll_I_slider = this.transform.Find("Display").Find("Roll").Find("I").GetComponent<SliderSync>();
        roll_D_slider = this.transform.Find("Display").Find("Roll").Find("D").GetComponent<SliderSync>();
    }

    public void ApplyButton()
    {
        ApplyNewData();
        DataManager.SaveAll();
        menuQuad.Respawn();
    }

    private void SendOldDataToUI()
    {
        pitch_P_slider.SetValue(PID_Properties.pitch_P);
        pitch_I_slider.SetValue(PID_Properties.pitch_I);
        pitch_D_slider.SetValue(PID_Properties.pitch_D);

        yaw_P_slider.SetValue(PID_Properties.yaw_P);
        yaw_I_slider.SetValue(PID_Properties.yaw_I);
        yaw_D_slider.SetValue(PID_Properties.yaw_D);

        roll_P_slider.SetValue(PID_Properties.roll_P);
        roll_I_slider.SetValue(PID_Properties.roll_I);
        roll_D_slider.SetValue(PID_Properties.roll_D);
    }

    private void ApplyNewData()
    {
        PID_Properties.pitch_P = pitch_P_slider.GetValue();
        PID_Properties.pitch_I = pitch_I_slider.GetValue();
        PID_Properties.pitch_D = pitch_D_slider.GetValue();

        PID_Properties.yaw_P = yaw_P_slider.GetValue();
        PID_Properties.yaw_I = yaw_I_slider.GetValue();
        PID_Properties.yaw_D = yaw_D_slider.GetValue();

        PID_Properties.roll_P = roll_P_slider.GetValue();
        PID_Properties.roll_I = roll_I_slider.GetValue();
        PID_Properties.roll_D = roll_D_slider.GetValue();
    }
}
