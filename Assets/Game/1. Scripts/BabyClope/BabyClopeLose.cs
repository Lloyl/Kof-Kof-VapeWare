using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyClopeLose : MonoBehaviour
{
    [SerializeField] private BabyClopeVictoryManager manager;

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.Instance.PlayAudio("Loupe Baby");
        manager.Lose();
    }
}