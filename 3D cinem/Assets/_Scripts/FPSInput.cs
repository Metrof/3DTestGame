using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    const float gravity = -9.8f;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float deltsX = Input.GetAxis("Horizontal") * speed;
        float deltsZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltsX, 0, deltsZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
