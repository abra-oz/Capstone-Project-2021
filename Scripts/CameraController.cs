using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Tooltip("The player character's Game Object")]
    public PlayerController player;
    [Tooltip("The distance the camera is from the character")]
    public float cameraZoom = 10;
    [Tooltip("The maximum distance that the camera can be offset from the player by the mouse's position")]
    public float maxMouseOffset = 3.5f;

    //private Ray rayPoint;

    void Start()
    {
        player.followCam.orthographicSize = cameraZoom;
        //player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // Sets desired position equal to players current position plus the clamped value of the mouse's location, plus the offset
        // 1.76 is the length of the side of a triangle with 80 degrees and a 10m side. Yay trig!
        Vector3 desiredPosition = player.transform.position + 
            Vector3.ClampMagnitude(player.playerInput.lookDir, maxMouseOffset) + 
            new Vector3(0, cameraZoom, -1.76f);

        // Camera follows your position
        // Transform the camera position to the character position plus a maximum of 2 meters away (plus the camera height).
        transform.position = desiredPosition;
    }

}
