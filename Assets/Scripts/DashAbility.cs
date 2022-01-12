using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{

    public DashState dashState;
    public float dashTimer;
    public float maxDash = 20f;

    public Vector3 savedVelocity;

    [SerializeField]
    KeyCode keyDash;

    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = Input.GetKeyDown(keyDash);
                if (isDashKeyDown)
                {
                    savedVelocity = GetComponent<Rigidbody>().velocity;
                    GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x * 2f, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z * 2f);
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    GetComponent<Rigidbody>().velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}