using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    [SerializeField] public Transform _player;
    [SerializeField] public float offsetX;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offsetX = 1.8f;
    }

    // Update is called once per frame

    void Update()
    {
        if (_player != null)
        {
            // Suivre uniquement la position X du joueur
            Vector3 cameraPosition = transform.position;
            cameraPosition.x = _player.position.x + offsetX;
            transform.position = cameraPosition;
        }
    }
}
