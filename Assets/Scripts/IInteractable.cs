using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class IInteractable
{
    [SerializeField] bool isEnabled = false;

    public void enable()
    {
        Debug.Log("Doin' shit");
    }

    public void disable()
    {
        Debug.Log("Doin' other shit");
    }
}
