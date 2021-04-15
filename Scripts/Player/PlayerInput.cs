using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Tooltip("This is the Character's PlayerController Script.")]
    public PlayerController playerController;

    // Contains the direction our object is moving.
    private Vector3 characterMovement = Vector3.zero;

    private Ray rayPoint;

    // Stores the mouse position later on
    internal Vector3 mousePos;

    [Tooltip("The direction the character is looking")]
    internal Vector3 lookDir;

    public Vector3 GetMouseMovement()
    {
        // Get the mouses position, converted to the position in the world, rather than the screen
        //- Store it in a raycast named 'rayPoint'
        rayPoint = playerController.followCam.ScreenPointToRay(Input.mousePosition);

        // Get the origin point of the rayCast and store it in 'mousePos' vector3
        mousePos = rayPoint.origin;

        // Get the line of (mousePos - player position) and store it in 'lookDir'
        // (https://youtu.be/LNLVOjbrQj4?t=409)
        lookDir = mousePos - playerController.rb.position;
        return lookDir;
    }

    public Vector3 GetAxisMovement()
    {
        // Take the Axis Speed (WASD) and apply it to the characterMovement vector
        characterMovement.x = Input.GetAxis("Horizontal");
        characterMovement.z = Input.GetAxis("Vertical");

        characterMovement = Vector3.ClampMagnitude(characterMovement, 1);

        return characterMovement;
    }

    public bool IsAttacking()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string IsDroppingItem()
    {
        if(Input.GetKey(KeyCode.Q) && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("HERE");
            return "Dropping Weapon";
        }
        else if (Input.GetKey(KeyCode.Q) && Input.GetButtonDown("Fire2"))
        {
            return "Dropping Magic";
        }
        return "nothing";
    }

    public bool IsSprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
