using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDrop : MonoBehaviour
{
    public GameObject Block;
    public GameObject spawnPt;
    public Player player;

    public void SpawnObject()
    {
        if (player.Block == 1)
        {
            Instantiate(Block, spawnPt.transform.position, Quaternion.identity);
            player.UseItem();
        }
        else
        {
            Debug.Log("You do not have enough to give");
            //print error
        }

    }
}
