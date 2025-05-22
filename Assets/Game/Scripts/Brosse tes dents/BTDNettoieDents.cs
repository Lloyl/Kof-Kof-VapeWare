using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.Touchscreen;

public class BTDNettoieDents : MonoBehaviour
{
    private bool canPlayAudio = true;

    //private float[] dentX = {53f, 68f, 86f, 110f, 132f, 148f, 48f, 58f, 70f, 89f, 111f, 131f, 142f, 155f};
    //private float[] dentY = {165f, 165f, 162f, 162f, 165f, 165f, 140f, 139f, 135f, 131f, 131f, 135f, 138f, 140f};
    
    [SerializeField] GameObject doigt;

    [SerializeField] GameObject[] Dents;


    private void Start()
    {
        canPlayAudio = true;
    }



    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (canPlayAudio){
                //AudioManager.Instance.PlayAudio(Audio.BTD_OUTIL);
                canPlayAudio = false;
            }

            Touch touchscreen = Touch.current;
            Vector2 touchPos_2 = touchscreen.primaryTouch.position.ReadValue();
            print("2" + touchPos_2);
            Vector3 touchPos_3 = new Vector3(touchPos_2.x, touchPos_2.y, Camera.main.WorldToScreenPoint(doigt.transform.position).z);
            print("3 : " + touchPos_3);
            doigt.transform.position = touchPos_3;
            print(doigt.transform.position);


        }
        else
        {
            //AudioManager.Instance.StopEffects();
            canPlayAudio = true;
        }
    }

/*
    float[] CalcPosition(GameObject dent)
    {
        float[] positionImg = new float[2];

        positionImg[0] = dent.transform.position.x; // ptet ça a modif 
        positionImg[1] = dent.transform.position.y;

        return positionImg;
    }

    bool IsOnDirt(float xImg, float yImg, float xPointer, float yPointer)
    {
        if ((xPointer - 10 <= xImg || xImg <= xPointer + 10) && (yPointer - 10 <= yImg || yImg <= yPointer + 10))
        {
            return true;
        }
        return false;
    }*/
}
