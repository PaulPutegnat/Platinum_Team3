using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTobogan : MonoBehaviour
{
    private Rigidbody rbRigidbody;
    private bool isGrounded;

    [Range(20.0f, 50f)]
    public float AccelerationTobogan;

    [Range(0.0f, 50f)]
    public float MaxSpeedTobogan;
    private float VelY;
    private float VelX;

    private float velocityXLastFrame;
    private void Awake()
    {
        rbRigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionStay(Collision other)
    {

        
        if (other.transform.CompareTag("tobogan"))
        {
            Debug.Log("ouiiiiiii");
            GetComponent<TESTCONTROLER>().jump = false;
            GetComponent<TESTCONTROLER>().ResetSlide();
            GetComponent<TESTCONTROLER>().enabled = false;

            VelY = rbRigidbody.velocity.y;
            VelX = rbRigidbody.velocity.x;

            if(rbRigidbody.velocity.magnitude < MaxSpeedTobogan || rbRigidbody.velocity.magnitude > -MaxSpeedTobogan)
                rbRigidbody.velocity = new Vector3(VelX * (1 + AccelerationTobogan / 1000), VelY * (1 + AccelerationTobogan / 1000), 0);

            

            if ((transform.position.x + GetComponent<BoxCollider>().bounds.size.x) - other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position).x > 0 && rbRigidbody.velocity.magnitude <0.1f)
            {
                rbRigidbody.velocity = new Vector3(10, 5, 0);
            }
            else if ((transform.position.x + GetComponent<BoxCollider>().bounds.size.x) - other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position).x < 0 && rbRigidbody.velocity.magnitude < 0.1f)
            {
                rbRigidbody.velocity = new Vector3(-10, 5, 0);
            }

            velocityXLastFrame = rbRigidbody.velocity.x;

        }
        

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("tobogan"))
        {
            GetComponent<TESTCONTROLER>().enabled = true;
            rbRigidbody.velocity = new Vector3(velocityXLastFrame, 1,0);
        }
    }
}
