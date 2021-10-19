using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    float CamSpeed;

    void Update()
    {
        transform.position += new Vector3(CamSpeed * Time.deltaTime, 0, 0);
    }
}
