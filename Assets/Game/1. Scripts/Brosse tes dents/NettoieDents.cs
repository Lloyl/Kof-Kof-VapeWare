using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NettoieDents : MonoBehaviour
{
    private bool _canPlayAudio = true;

    [SerializeField] private GameObject doigt;

    private void Start()
    {
        _canPlayAudio = true;
    }

    private void Update()
    {
        if (Input.touchCount == 0) return;

        if (_canPlayAudio)
        {
            // AudioManager.Instance.PlayAudio("Outil dentiste");
            _canPlayAudio = false;
        }

        var touch = Input.GetTouch(0);


        // doigt.transform.position = new Vector3(GetXDoigtCoord(touch.position.x), GetYDoigtCoord(touch.position.y),
        //                                        doigt.transform.position.z);
        var touchPos = new Vector3(GetXDoigtCoord(touch.position.x), GetYDoigtCoord(touch.position.y),
                                   doigt.transform.position.z);
        Debug.Log("WORLD: "+Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane)).ToString("F3"));
        doigt.transform.position = touchPos;
        print(touchPos + ", " + Screen.width + ", " + Screen.height);
    }

    private static float GetXDoigtCoord(float coord)
    {
        return (coord - 540) * 5.7f / 540f;
    }

    private float GetYDoigtCoord(float coord)
    {
        if (coord <= 1200)
        {
            return (coord - 864) * 9f / 864f;
        }

        return doigt.transform.position.y;
    }
}