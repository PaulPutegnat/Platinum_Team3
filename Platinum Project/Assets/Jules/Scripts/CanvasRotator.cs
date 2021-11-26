using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRotator : MonoBehaviour
{
    private RectTransform canvasRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        canvasRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        canvasRectTransform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
