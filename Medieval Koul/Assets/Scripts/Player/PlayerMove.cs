using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //declarer les variables
    public float moveSpeed;

    public bool isMoving;
    private Vector2 input;

    private void Update()
    {
        if (!isMoving) {
            input.x = Input.GetAxisRaw("Horizontal");
            input.x = Input.GetAxisRaw("Vertical");

        }
    }
}
