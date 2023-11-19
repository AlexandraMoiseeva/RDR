using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Account : MonoBehaviour
{
    public TMP_Text displayName;
    // Start is called before the first frame update
    void Start()
    {
        displayName.text = DataManager.displayName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
