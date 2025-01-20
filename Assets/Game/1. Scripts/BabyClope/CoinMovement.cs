using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody coinBody;
    [SerializeField] private int       coinSpeed = 100;

    private bool _hasBeenHit;
    private bool _canPush;
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {
        if (_hasBeenHit) return;

        _hasBeenHit = true;
        _canPush    = true;
    }

    private void FixedUpdate()
    {
        if (!_canPush) return;

        coinBody.AddForce(new Vector3(0, 0, 1) * coinSpeed);
        _canPush = false;
    }
}