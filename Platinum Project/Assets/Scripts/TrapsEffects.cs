using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapsEffects : MonoBehaviour
{
    public GameObject SceneCamera;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("test");
            SceneCamera.transform.rotation *= Quaternion.Euler(0, 0, 180);
        }
    }
}
