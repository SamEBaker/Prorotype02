using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour

//on collision if with player then call damage player function
//in player controler if player dies disable movement iskinetic (add to lose screen) and prompt repawn to minus gold 
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}

