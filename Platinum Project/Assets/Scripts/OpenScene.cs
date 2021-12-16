using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenScene : MonoBehaviour
{
    public Image black;
    public Animator anim;
    public TextMeshPro text;

    void Update()
    {
        if (Input.anyKeyDown || Gamepad.current.allControls.Any(x => x is ButtonControl button && x.IsPressed(1) && !x.synthetic))
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        AudioManager.Instance.PlaySingleSound("Button_Click_Sound");
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Main Menu_Particules");
    }
}
