using UnityEngine;

public class BCCoinMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody coinBody;
    [SerializeField] private int       coinSpeed;
    
    [SerializeField] private BCGameManager gameManager;
    
    [SerializeField] private GameObject linePath;

    private bool _hasShoot;
    private bool _hasHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasHit) return;
        _hasHit = true;
        
        coinBody.linearDamping = 15; // stop le coin après le hit

        var win = collision.gameObject.CompareTag(Constants.TAG_BC_SAFEBOX);

        gameManager.OnCoinHit(win);
    }

    private void Update()
    {
        // computer
        #if UNITY_EDITOR || UNITY_STANDALONE
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

        Shoot();
        #endif

        // mobile
        #if UNITY_ANDROID || UNITY_IPHONE
        if (Input.touches.Length < 1) return;
    
        Shoot();
        #endif
    }

    private void Shoot()
    {
        if (_hasShoot) return;

        AudioManager.Instance.PlayAudio(Audio.BC_TIR);
        coinBody.AddForce(Vector3.forward * coinSpeed);
        linePath.SetActive(false);
        _hasShoot = true;
    }
}