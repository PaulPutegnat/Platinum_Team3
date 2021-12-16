using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MaterialDispenser : MonoBehaviour
{
    private GameObject playerRefForMat;
    public static MaterialDispenser Instance;

    public Material[] matArrayMaterials1;
    public Material[] matArrayMaterials2;
    // Start is called before the first frame update

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ApplyMat()
    {
        playerRefForMat = PlayerManagerScript.Instance.players[0].GetComponent<neutralcontroller>().runnerRef;
        GameObject Idle = playerRefForMat.transform.GetChild(0).gameObject;

        for (int i = 0; i < Idle.transform.childCount - 1; i++)
        {
            GameObject child = Idle.transform.GetChild(i).gameObject;
            Material[] mats = child.GetComponent<SkinnedMeshRenderer>().materials;

            switch (i)
            {
                case 0:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 1:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 2:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 3:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 4:
                    mats[0] = matArrayMaterials1[1];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 5:
                    mats[0] = matArrayMaterials1[1];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 6:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 7:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 8:
                    mats[0] = matArrayMaterials1[1];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 9:
                    mats[0] = matArrayMaterials1[1];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 10:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 11:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 12:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 13:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 14:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 15:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 16:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 17:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 18:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
                case 19:
                    mats[0] = matArrayMaterials1[0];
                    child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                    break;
            }





        }

        if (PlayerManagerScript.Instance.players[1] != null)
        {
            playerRefForMat = PlayerManagerScript.Instance.players[1].GetComponent<neutralcontroller>().runnerRef;
            for (int i = 0; i < Idle.transform.childCount - 1; i++)
            {
                GameObject child = Idle.transform.GetChild(i).gameObject;
                Renderer rend = child.GetComponent<Renderer>();
                Material[] mats = child.GetComponent<SkinnedMeshRenderer>().materials;
                switch (i)
                {
                    case 0:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 1:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 2:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 3:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 4:
                        mats[0] = matArrayMaterials2[1];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 5:
                        mats[0] = matArrayMaterials2[1];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 6:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 7:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 8:
                        mats[0] = matArrayMaterials2[1];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 9:
                        mats[0] = matArrayMaterials2[1];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 10:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 11:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 12:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 13:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 14:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 15:
                        mats[0] = matArrayMaterials2[2];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 16:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 17:
                        mats[0] = matArrayMaterials2[0];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 18:
                        mats[0] = matArrayMaterials2[2];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                    case 19:
                        mats[0] = matArrayMaterials2[2];
                        child.GetComponent<SkinnedMeshRenderer>().sharedMaterials = mats;
                        break;
                }
            }
        }
    }
}