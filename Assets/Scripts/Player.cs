using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{       
    public Rigidbody rb;
    public float playerSpeed;
    public int Keys = 0;
    public float currSpeed = 0;
    public float sprintSpeed;
    public Vector3 movement;
    public int playerHealth = 100;
    float hInput;
    public int Block = 0;
    public Transform orientation;
    float vInput;
    public int Gear = 0;
    public HUDManager hud;
    public float rotSpeed;
    public  bool IsDead;
    public GameManager gm;
    public int PadKey;
    public GameObject RespawnPoint;

    //If player has gears setactive sprite in inventory with child of text displaying amount
    //same for sword
    //equipscript to player and target to object to drop but set drop to invenmtory  button not keybind

    public StaminaController staminaController;
    public Transform cam;
    public CharacterController controller;

    void Start()
    {
        Keys = 0;
        staminaController = GetComponent<StaminaController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void OnYesButton()
    {
        Respawn();
    }
    public void OnNoButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Update()
    {
        if (IsDead)
        {
            playerHealth = 0;
            //rb.isKinematic = true;
            hud.DisplayDeath();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (staminaController.playerStamina > 5f)
            {
                staminaController.isSprinting = true;
                staminaController.Sprinting(); ;
                staminaController.UpdateStamina(1);
                currSpeed = playerSpeed + sprintSpeed;
            }
            else if (staminaController.playerStamina <= 5f)
            {
                staminaController.isSprinting = false;
                staminaController.UpdateStamina(0);
                currSpeed = playerSpeed;
            }
        }
        else
        {
            staminaController.isSprinting = false;
            staminaController.UpdateStamina(0);
            currSpeed = playerSpeed;
        }


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //currentState.Handle(this);
    }

    void FixedUpdate()
    {
        rb.velocity = (movement * currSpeed);
    }

    public void TakeDamage()
    {
        if(playerHealth <= 0)
        {
            IsDead = true;
        }
        else
        {
            playerHealth -=5;
            hud.DisplayplayerHealth();
        }

    }

    public void Respawn()
    {
        IsDead = false;
        transform.position = RespawnPoint.transform.position;
        playerHealth = 100;
        //rb.isKinematic = false;
        //gm.loseGold(10);
        hud.DisplayDisableDeath();
    }
    /*
    private void Awake()
    {
        currentState = new GameManager();
    }
    */

    public void AddGear()
    {
        Gear += 1;

    }
    public void AddBlock()
    {
        if(Block == 0)
        {
            Block += 1;
        }
        else
        {
            Debug.Log("You can only hold one block at a time");
        }

    }
    public void UnlockDoor()
    {
        Keys +=1;
    }

    public void UseItem()
    {
        //update ui for inventory
        if(Gear != 0)
        {
            Gear -= 1;
            hud.DisplayGears();
        }
        else
        {
            //print error message
        }
    }
}
