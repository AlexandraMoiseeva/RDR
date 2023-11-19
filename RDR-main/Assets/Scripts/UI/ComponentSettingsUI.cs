using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ComponentSettingsUI : MonoBehaviour
{
    public List<MenuPanelComponent> componentPanels;

    public SliderSync batteryMass_slider, batteryCapacity_slider;
    public SliderSync quadMass_slider;
    public SliderSync camMass_slider, camFOV_slider, camAngle_slider;

    void Start()
    {
        SetDataToUI();
        ShowPanel(null);
    }

    private void SetDataToUI()
    {
        camMass_slider.SetValue(CameraProperties.mass);
        camFOV_slider.SetValue(CameraProperties.FOV);
        camAngle_slider.SetValue(CameraProperties.angle);

        quadMass_slider.SetValue(QuadCharacteristics.mass);

        batteryMass_slider.SetValue(Baterry.mass);
        batteryCapacity_slider.SetValue(Baterry.capacity);
    }

    private void SaveCameraProperties()
    {
        CameraProperties.mass = camMass_slider.GetValue();
        CameraProperties.FOV = camFOV_slider.GetValue();
        CameraProperties.angle = camAngle_slider.GetValue();
    }

    private void SaveBattery()
    {
        Baterry.mass = batteryMass_slider.GetValue();
        Baterry.capacity = batteryCapacity_slider.GetValue();
    }

    private void SaveQuadProperties()
    {
        QuadCharacteristics.mass = quadMass_slider.GetValue();
    }

    public void Apply()
    {
        SaveCameraProperties();
        SaveBattery();
        SaveQuadProperties();
        DataManager.SaveAll();
    }

    public void ShowPanel(string panelName)
    {
        foreach (MenuPanelComponent panel in componentPanels)
        {
            if (panel.name == panelName)
                panel.Show();
            else
                panel.Hide();
        }
    }
}
