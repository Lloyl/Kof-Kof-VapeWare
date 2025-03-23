using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interaction = GameStats.Interaction;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private GameObject tap;
    [SerializeField] private GameObject spam;
    [SerializeField] private GameObject drag;
    [SerializeField] private GameObject rug;

    // Module à revoir, non utilisé
    public void ActivateAnimation(Interaction gameplay)
    {
        foreach (Transform anim in transform)
        {
            anim.gameObject.SetActive(false);
        }

        switch (gameplay)
        {
            case Interaction.TAP:
                tap.SetActive(true);
                break;
            case Interaction.DRAG:
                drag.SetActive(true);
                break;
            case Interaction.RUG:
                rug.SetActive(true);
                break;
            case Interaction.MULTI_TAP:
                spam.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameplay), gameplay, null);
        }
    }
}