using UnityEngine;

public class BCCoinMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody coinBody;
    [SerializeField] private int       coinSpeed = 100;

    private bool StopCoin { get; set; }

    public delegate void CoinHit(bool win);

    public event CoinHit OnCoinHitEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (
            !collision.gameObject.CompareTag("Clope") ||
            !collision.gameObject.CompareTag("BCSafebox"))
            return;

        StopCoin = true;

        coinBody.linearDamping = 13;

        var win = collision.gameObject.CompareTag("Clope") || collision.gameObject.CompareTag("BCSafebox");

        OnCoinHitEvent?.Invoke(win);
    }

    private void FixedUpdate()
    {
        if (StopCoin) return;

        coinBody.AddForce(Vector3.forward * coinSpeed);
    }
}