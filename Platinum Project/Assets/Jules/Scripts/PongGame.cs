using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGame : MonoBehaviour
{

    public GameObject _PongBarGameObject;
    public float _PongBarSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void MovePongBar(Vector2 newPos)
    {
        _PongBarGameObject.transform.Translate(new Vector3(0, newPos.y * _PongBarSpeed * Time.deltaTime, 0));
    }
}
