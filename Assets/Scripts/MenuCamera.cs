using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public float MoveSpeed = 5f;
    private bool isRotate;
    private float startPointerPos;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isRotate = true;
            startPointerPos = Input.mousePosition.x;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isRotate = false;
        }

        if (isRotate)
        {
            float currentPointerPos = Input.mousePosition.x;
            float pointerMovement = currentPointerPos - startPointerPos;

            transform.Rotate(Vector3.up, -pointerMovement * MoveSpeed * Time.deltaTime);
            startPointerPos = currentPointerPos;
        }
    }
}
