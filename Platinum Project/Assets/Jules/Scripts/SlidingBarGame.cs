using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingBarGame : MonoBehaviour
{
    public GameObject handle;
    public GameObject slidingBox;
    public GameObject interval;
    public float speed;

    public float minIntervalPos, maxIntervalPos;
    public float intervalSize;

    private Vector3 startPos;
    private float maxBoundBox;

    void Start()
    {
        startPos = handle.transform.localPosition;
        maxBoundBox = slidingBox.GetComponent<RectTransform>().sizeDelta.x - 10f;
        //interval.GetComponent<RectTransform>().sizeDelta.x = intervalSize;

    }
    void Update()
    {
        handle.transform.localPosition = new Vector3(startPos.x + Mathf.PingPong(Time.time * speed, maxBoundBox), handle.transform.localPosition.y, 0);
    }
}
