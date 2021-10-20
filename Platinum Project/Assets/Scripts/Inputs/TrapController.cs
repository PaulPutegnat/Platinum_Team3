using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrapController : MonoBehaviour
{
    public GameObject[] Traps = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject == GameManager.gameManager.players[2])
        {
            Traps[0] = GameObject.Find("Trap1");
            Traps[1] = GameObject.Find("Trap2");
        }
        else if (this.gameObject == GameManager.gameManager.players[3])
        {
            Traps[0] = GameObject.Find("Trap3");
            Traps[1] = GameObject.Find("Trap4");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
