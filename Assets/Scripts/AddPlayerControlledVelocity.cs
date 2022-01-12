using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 v3ForceX;

    [SerializeField]
    Vector3 v3ForceY;

    [SerializeField]
    Vector3 jumpForce;

    [SerializeField]
    KeyCode keyPositiveX;

    [SerializeField]
    KeyCode keyNegativeX;

    [SerializeField]
    KeyCode keyPositiveY;

    [SerializeField]
    KeyCode keyNegativeY;

    [SerializeField]
    KeyCode keyJump;

    void FixedUpdate()
    {

        GetComponent<Rigidbody>().AddForce(Physics.gravity * 3f, ForceMode.Acceleration);


        if (Input.GetKey(keyPositiveX))
            GetComponent<Rigidbody>().velocity += v3ForceX;

        if (Input.GetKey(keyNegativeX))
            GetComponent<Rigidbody>().velocity -= v3ForceX;

        if (Input.GetKey(keyPositiveY))
            GetComponent<Rigidbody>().velocity += v3ForceY;

        if (Input.GetKey(keyNegativeY))
            GetComponent<Rigidbody>().velocity -= v3ForceY;

    }

    void Update()
    {
        if (Input.GetKeyDown(keyJump))
            GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Impulse);
    }

}
