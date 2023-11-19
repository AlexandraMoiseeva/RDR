using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic _instance;

    public void OnEnable()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Awake()
    {
        if (_instance) DestroyImmediate(gameObject);
    }

    private void Update()
    {
       GetComponent<AudioSource>().volume = Parameters.musicVolume;
    }
}
