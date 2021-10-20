using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class neutralcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    private float posTrapper = 517f;
    private float posRunner = -459f;
    private bool Comfirmation = false;

    public void ChangeTeam(InputAction.CallbackContext context)
    {
        if (!Comfirmation)
        {
                float y = GetComponent<RectTransform>().anchoredPosition.y;
                Debug.Log((context.ReadValue<Vector2>().x));
                Vector2 dir = context.ReadValue<Vector2>();
                if (dir.x < -0.25f)
                {
                    if (GetComponent<RectTransform>().anchoredPosition.x == 0)
                    {
                         GameManager.gameManager.RunnererNumber++;
                        GetComponent<RectTransform>().anchoredPosition = new Vector3(posRunner, y, 0);               
                    }
                    else
                    {
                        GameManager.gameManager.TrapperNumber--;
                        GameManager.gameManager.RunnererNumber++;
                        GetComponent<RectTransform>().anchoredPosition = new Vector3(posRunner, y, 0);
                    }
                    

                }
                

                if (dir.x > 0.25f)
                {
                    if (GetComponent<RectTransform>().anchoredPosition.x == 0)
                    {
                        GameManager.gameManager.TrapperNumber++;
                        GetComponent<RectTransform>().anchoredPosition = new Vector3(posTrapper, y, 0);                
                    }
                    else
                    { 
                        GameManager.gameManager.TrapperNumber++;
                        GameManager.gameManager.RunnererNumber--;
                        GetComponent<RectTransform>().anchoredPosition = new Vector3(posTrapper, y, 0);               
                    }

                }

            }
        }
        

    public void Confirmation(InputAction.CallbackContext context)
    {
        Comfirmation = true;
    }
    public void Back(InputAction.CallbackContext context)
    {
        Comfirmation = false;
    }


}
