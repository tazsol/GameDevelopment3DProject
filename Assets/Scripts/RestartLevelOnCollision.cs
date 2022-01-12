using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelOnCollision : MonoBehaviour
{

    [SerializeField]
    string stringTagOne;

    [SerializeField]
    string stringTagTwo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == stringTagOne || collision.collider.tag == stringTagTwo)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
