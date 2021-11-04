using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTobogan : MonoBehaviour
{
    private Rigidbody rbRigidbody;
    private bool isGrounded;

    [Range(0.0f, 50f)]
    public float AccelerationTobogan;

    [Range(0.0f, 50f)]
    public float MaxSpeedTobogan;
    private float VelY;
    private float VelX;

    private void Awake()
    {
        rbRigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionStay(Collision other)
    {

        
        if (other.transform.tag == "tobogan")
        {
            Debug.Log("ouiiiiiii");
            GetComponent<TESTCONTROLER>().enabled = false;

            VelY = rbRigidbody.velocity.y;
            VelX = rbRigidbody.velocity.x;

            if(rbRigidbody.velocity.magnitude < MaxSpeedTobogan || rbRigidbody.velocity.magnitude > -MaxSpeedTobogan)
                rbRigidbody.velocity = new Vector3(VelX * (1 + AccelerationTobogan / 1000), VelY * (1 + AccelerationTobogan / 1000), 0);
            
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("tobogan"))
        {
            GetComponent<TESTCONTROLER>().enabled = true;
        }
    }
}
