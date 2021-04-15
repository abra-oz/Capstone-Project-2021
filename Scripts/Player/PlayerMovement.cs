using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Get the PlayerController Script for use in Movement
    public PlayerController playerController;
    public PlayerInput playerInput;
    

    

    public void MoveCharacter(Vector3 axisMovement)
    {
        // Move the object based on the characterMovement (maxed out at 1), 
        //- times our movement Speed Variable (and delta time).
        playerController.rb.MovePosition(playerController.rb.position + 
            (Vector3.ClampMagnitude(axisMovement, 1) * 
            playerController.movementSpeed * Time.deltaTime));
    }
    
    public void RotateCharacter(Vector3 mousePosition)
    {
        Vector3 velocity = Vector3.zero;

        float angle = Mathf.Atan2(mousePosition.x, mousePosition.z) * Mathf.Rad2Deg;
        playerController.transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    public void Sprint(bool sprinting)
    {
        
        if (sprinting)
        {
            playerController.movementSpeed = playerController.nonSprintSpeed * playerController.characterSprintMultiplier;
        }
        if (!sprinting)
        {
            playerController.movementSpeed = playerController.nonSprintSpeed;
        }
            
    }
    

}
