using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsOffCamera : MonoBehaviour
{
    public GameObject TrappersWin;
    public Vector2 widthThresold;
    public Vector2 heightThresold;

    public GameObject Particles;

    private GameObject ParticleCopy;
    // Start is called before the first frame update

    private int times = 1;
    private void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if ((screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y ||
            screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y )&& times == 1)
        {
            ParticleCopy = Instantiate(Particles, transform.position, Quaternion.identity,transform.parent);
            ParticleCopy.GetComponent<ParticleSystem>().Play();
            TrappersWin.SetActive(true);
            times--;
            transform.parent.transform.parent.gameObject.GetComponent<TESTCONTROLER>().enabled = false;
            transform.parent.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            foreach (Transform childTransform in transform.parent)
            {
                if(childTransform.GetComponent<SkinnedMeshRenderer>())
                    childTransform.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            Destroy(transform.parent.transform.parent.gameObject,4);
        }
    }

}
