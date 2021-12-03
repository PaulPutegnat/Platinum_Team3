using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    private Rigidbody rb;

    private TrailRenderer trail;

    private float TimeBeforeStopEmission = 0.2f;

    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = TimeBeforeStopEmission;
           rb = GetComponentInParent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();

        trail.emitting = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < -10)
        {

            trail.emitting = true;
            Timer = TimeBeforeStopEmission;
        }
        else
        {
            if (Timer > 0)
            {

                Timer -= Time.deltaTime;
            }
            else
            {
                trail.emitting = false;
                Timer = TimeBeforeStopEmission;
            }

        }
    }
}
