using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropButton : MonoBehaviour
{
    public BlockDrop bd;
    public void ClickTest()
    {
        Debug.Log("I have been pressed");
        bd.SpawnObject();
    }
}
