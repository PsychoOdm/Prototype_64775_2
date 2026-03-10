using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerTutorialUpdates : MonoBehaviour
{
    public InputAction LeftAction;
    public InputAction MoveAction;

    void Start()
    {
         MoveAction.Enable(); 
        LeftAction.Enable();
       
    }

   void Update()
 
   {
     Vector2 move = MoveAction.ReadValue<Vector2>();
     Debug.Log(move);
     Vector2 position = (Vector2)transform.position + move * 0.1f;
     transform.position = position;
   

        /*
        // 
        float horizontal = 0.0f;

        if (LeftAction.IsPressed())
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
        }

        Debug.Log(horizontal);

        float vertical = 0.0f;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 1.0f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -1.0f;
        }

        Debug.Log(vertical);

        Vector2 positionOld = transform.position;
        positionOld.x += 0.1f * horizontal;
        positionOld.y += 0.1f * vertical;
        transform.position = positionOld;
        */
    }
}