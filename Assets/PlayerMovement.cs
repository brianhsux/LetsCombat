using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 4f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            Debug.Log("w clicked");
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("s down clicked");
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) {
            Debug.Log("s up clicked");
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
