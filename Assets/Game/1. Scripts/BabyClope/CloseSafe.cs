using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSafe : MonoBehaviour
{
    [SerializeField] private BabyClopeVictoryManager manager;

    private void OnTriggerEnter(Collider other)
    {
        manager.Win();
    }
}