using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MiniGame : MonoBehaviour
{
    public List<AnimationClip> SpawnAnim = new List<AnimationClip>();
    public List<AnimationClip> DespawnAnim = new List<AnimationClip>();

    [SerializeField] private GameObject LosePrefab;
    [SerializeField] private GameObject WinPrefab;
    [SerializeField] private GameObject HammerPrefab;

    protected bool IsGameFinishLoseCoroutineStarted = false;
    protected bool IsGameFinishWinCoroutineStarted = false;
    protected bool IsHammerCoroutineStarted = false;
    protected bool isGameBegin = false;

    public IEnumerator SpawnAnimation()
    {
        Animator fwAnimation = GetComponentInParent<Animator>();
        int RandomIndex = Random.Range(0, SpawnAnim.Count);
        fwAnimation.Play(SpawnAnim[RandomIndex].name);
        yield return new WaitForSeconds(SpawnAnim[RandomIndex].length);
    }

    public IEnumerator DespawnAnimation()
    {
        Animator fwAnimation = GetComponentInParent<Animator>();
        int RandomIndex = Random.Range(0, DespawnAnim.Count);
        fwAnimation.Play(DespawnAnim[RandomIndex].name);
        yield return new WaitForSeconds(DespawnAnim[RandomIndex].length);
    }

    public IEnumerator SpawnEffect(GameObject prefab, GameObject target, Vector2 offset)
    {
        Vector3 targetPos = target.transform.position;
        GameObject instGameObject = Instantiate(prefab, (Vector2)targetPos + offset, Quaternion.identity, this.transform);
        Animator instAnimator = instGameObject.GetComponentInChildren<Animator>();
        yield return new WaitForSeconds(instAnimator.GetCurrentAnimatorClipInfo(0).Length);
        Destroy(instGameObject);
    }

    public IEnumerator GameFinishLose()
    {
        IsGameFinishLoseCoroutineStarted = true;
        yield return StartCoroutine(DespawnAnimation());
        GameObject instGameObject = Instantiate(LosePrefab, GameObject.FindGameObjectWithTag("GameContainer").transform);
        Animator myAnimator = instGameObject.GetComponent<Animator>();
        yield return new WaitForSeconds(myAnimator.runtimeAnimatorController.animationClips[0].length);
        Destroy(instGameObject);

        GameManager.Instance.SpawnFortuneWheel();
        Destroy(this.transform.parent.gameObject);
        
    }

    public IEnumerator GameFinishWin(float trapIndex)
    {
        IsGameFinishWinCoroutineStarted = true;
        StartCoroutine(DespawnAnimation());
        GameObject instGameObject = Instantiate(WinPrefab, GameObject.FindGameObjectWithTag("GameContainer").transform);
        TextMeshProUGUI gameText = instGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI effectText = instGameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        switch (trapIndex)
        {
            case 1:
                gameText.text = "Game win";
                break;
            case 1.2f:
                gameText.text = "Game Semi-win";
                break;
        }
        switch (TrapsEffects.instanceTrapsEffects.trapNum)
        {
            case 1:
            case 2:
            case 3:
                effectText.text = "SCHNELL !";
                break;
            case 4:
            case 5:
                effectText.text = "WATCH OUT ! A ROCK !";
                break;
            case 6:
                effectText.text = "SHAKE YOUR BOOTY !";
                break;
        }
        Animator myAnimator = instGameObject.GetComponent<Animator>();
        yield return new WaitForSeconds(myAnimator.runtimeAnimatorController.animationClips[0].length);

        Destroy(instGameObject);

        TrapsEffects.instanceTrapsEffects.TrapSelector(trapIndex);
        GameManager.Instance.SpawnFortuneWheel();
        Destroy(this.transform.parent.gameObject);
    }

    public IEnumerator HammerShake()
    {
        IsHammerCoroutineStarted = true;
        yield return StartCoroutine(DespawnAnimation());
        GameObject instGameObject = Instantiate(HammerPrefab, GameObject.FindGameObjectWithTag("GameContainer").transform);
        Animator myAnimator = instGameObject.GetComponent<Animator>();
        yield return new WaitForSeconds(myAnimator.runtimeAnimatorController.animationClips[0].length);
        Destroy(instGameObject);

        GameManager.Instance.SpawnFortuneWheel();
        Destroy(this.transform.parent.gameObject);
    }
}
