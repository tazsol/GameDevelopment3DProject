using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 v3Force;

    [SerializeField]
    Vector3 jumpForce;

    [SerializeField]
    KeyCode keyPositive;

    [SerializeField]
    KeyCode keyNegative;

    [SerializeField]
    KeyCode keyJump;

    void FixedUpdate()
    {
        if (Input.GetKey(keyPositive))
            GetComponent<Rigidbody>().velocity += v3Force;

        if (Input.GetKey(keyNegative))
            GetComponent<Rigidbody>().velocity -= v3Force;

    }

    void Update()
    {
        if (Input.GetKeyDown(keyJump))
            GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.LeftShift))
            StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time; // need to remember this to know how long to dash
        while (Time.time < startTime + 100)
        {
            transform.Translate(transform.forward * 5 * Time.deltaTime);
            // or controller.Move(...), dunno about that script
            yield return null; // this will make Unity stop here and continue next frame
        }
    }

}
