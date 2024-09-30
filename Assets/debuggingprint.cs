using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuggingprint : MonoBehaviour
{
    public GearDrop gd;
    public void ClickTest()
    {
        Debug.Log("I have been pressed");
        gd.SpawnObject();
    }
}
