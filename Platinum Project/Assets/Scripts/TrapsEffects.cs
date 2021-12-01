using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapsEffects : MonoBehaviour
{
    public static TrapsEffects instanceTrapsEffects;
    public GameObject BrokenScreen;
    public GameObject Rock;

    private float _timer = 0;
    private float _percent;
    private Vector3 _rockStart;
    private Vector3 _rockTarget = new Vector3(0,0,0);

    private void Awake()
    {
        if (instanceTrapsEffects != null && instanceTrapsEffects != this)
            Destroy(gameObject);

        instanceTrapsEffects = this;
    }

    private void Start()
    {
        _rockStart = Rock.transform.position;
        _timer += Time.deltaTime;
        _percent = _timer / 2f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            BrokenScreenEffect();
        }
    }

    public void BrokenScreenEffect()
    {
        Rock.SetActive(true);
        Rock.transform.position = Vector3.Lerp(_rockStart,_rockTarget, _percent);

        if (_rockStart == _rockTarget)
        {
            BrokenScreen.SetActive(true);
            Debug.Log("Broken!");
        }
    }
}
