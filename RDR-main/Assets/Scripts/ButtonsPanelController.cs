using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ButtonsPanelController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnWorkshopClick()
    {
        animator.SetTrigger("Replace");
    }
}
