using UnityEngine;

public class SCFollowPlayer : MonoBehaviour
{
    [SerializeField] public Transform player;

    [SerializeField] public float offsetX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        offsetX = 1.8f;
    }

    // Update is called once per frame

    public void Update()
    {
        // Suivre uniquement la position X du joueur
        var cameraPosition = transform.position;
        
        cameraPosition.x   = player.position.x + offsetX;
        transform.position = cameraPosition;
    }
}