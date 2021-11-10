using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGame : MonoBehaviour
{
    public GameObject _PongBarP1GameObject;
    public GameObject _PongBarP2GameObject;
    public float _PongBarSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void MoveP1PongBar(Vector2 newPos)
    {
        _PongBarP1GameObject.transform.Translate(new Vector3(0, newPos.y * _PongBarSpeed * Time.deltaTime, 0));
    }
    
    public void MoveP2PongBar(Vector2 newPos)
    {
        _PongBarP2GameObject.transform.Translate(new Vector3(0, newPos.y * _PongBarSpeed * Time.deltaTime, 0));
    }
}
