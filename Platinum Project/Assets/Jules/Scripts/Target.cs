using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float decrementValue;
    public float timeBfShrinking;
    public float disapearTime;
    private float xtargetScale;
    private Vector3 targetScale;

    // Start is called before the first frame update
    void Start()
    {
        xtargetScale = GetComponent<RectTransform>().localScale.x;
        targetScale = GetComponent<RectTransform>().localScale;
        StartCoroutine(Shrinking());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shrinking()
    {
        yield return new WaitForSeconds(timeBfShrinking);
        for (float i = xtargetScale; i > 0; i -= 0.05f)
        {
            targetScale -= new Vector3(decrementValue, decrementValue, decrementValue);
        }
    }
}
