using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearDrop : MonoBehaviour
{
    public GameObject gearObj;
    public GameObject spawnPt;
    public Player player;

    public void SpawnObject()
    {
        if(player.Gear != 0)
        {
            Instantiate(gearObj, spawnPt.transform.position, Quaternion.identity);
            player.UseItem();
        }
        else
        {
            Debug.Log("You do not have enough to give");
            //print error
        }

    }

}
