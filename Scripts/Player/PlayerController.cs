using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [Header("Player Scripts")]
    [Tooltip("Put the Character's PlayerAttack Script here.")]
    public PlayerAttack playerAttack;
    [Tooltip("Put the Character's PlayerCollision Script here.")]
    public PlayerCollision playerCollision;
    [Tooltip("Put the Character's PlayerInput Script here.")]
    public PlayerInput playerInput;
    [Tooltip("Put the Character's PlayerMovement Script here.")]
    public PlayerMovement playerMovement;
    [Tooltip("Put the Character's Inventory Script here.")]
    public Inventory inventory;

    [Header("Drag and Drop")]
    [Tooltip("The camera that follows the character (Probably Main)")]
    public Camera followCam;
    [Tooltip("The 3D model of the character")]
    public Transform model;
    [Tooltip("The 'Filled Health Bar' Object")]
    public Transform Health;
    [Tooltip("The 'Filled Mana Bar' Object")]
    public Transform Mana;

    [Header("Player Stats")]
    [Tooltip("The max health of the character")]
    public float maxHealth = 100;
    [Tooltip("The max mana of the character")]
    public float maxMana = 100;
    [Tooltip("The speed of the character")]
    public float movementSpeed = 10.5f;
    [Tooltip("The sprint multiplier of the character")]
    public float characterSprintMultiplier = 1.75f;

    // Rigidbody component
    [HideInInspector] public Rigidbody rb;
    internal float nonSprintSpeed;

    // Start is called before the first frame update
    void Start()
    {
        nonSprintSpeed = movementSpeed;

        Debug.Log("The PlayerController is starting up!");

        // The Rigidbody attached to this object.
        rb = GetComponent<Rigidbody>();

        // Set the starting rotation for the camera
        followCam.transform.Rotate(80, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInput.GetAxisMovement() != null)
        {
            playerMovement.MoveCharacter(playerInput.GetAxisMovement());
        }

        if (playerInput.IsAttacking())
        {
            playerAttack.AttackEnemies();
        }

        if (playerInput.IsDroppingItem() == "Dropping Weapon")
        {
            inventory.equippedWeapon.DropWeapon(transform.position);
        }
        else if (playerInput.IsDroppingItem() == "Dropping Magic")
        {

        }

        if (playerInput.IsSprinting())
        {
            playerMovement.Sprint(playerInput.IsSprinting());
        }    
        else if (!playerInput.IsSprinting())
        {
            playerMovement.Sprint(playerInput.IsSprinting());
        }
    }

    void LateUpdate()
    {
        if (playerInput.GetMouseMovement() != null)
        {
            playerMovement.RotateCharacter(playerInput.GetMouseMovement());
        }
    }
}