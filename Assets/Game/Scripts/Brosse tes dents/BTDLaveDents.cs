using TMPro;
using UnityEngine;

public class BTDLaveDents : MonoBehaviour
{
    public bool hasWin;
    int dent1Counter = 0;
    int dent2Counter = 0;
    int dent3Counter = 0;
    int dent4Counter = 0;
    int dent5Counter = 0;
    int dent6Counter = 0;
    int dent7Counter = 0;
    int dent8Counter = 0;
    int dent9Counter = 0;
    int dent10Counter = 0;
    int dent11Counter = 0;
    int dent12Counter = 0;
    int dent13Counter = 0;
    int dent14Counter = 0;

    private int[] Dents;

    private bool canPlayAudio = true;

    private void OnTriggerEnter(Collider other)
    {
        hasWin = false;

        if (!other.gameObject.CompareTag("Dent")) return;

        print("other.gameObject.GetComponent<SpriteRenderer>().color.a :" + other.gameObject.GetComponent<SpriteRenderer>().color.a);

        int dent = int.Parse(other.gameObject.name[3..]);
        Dents[dent]++;
        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);

        //switch (dentTouched)
        //{
        //    case "Dent1":
        //        dent1Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent2":
        //        dent2Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent3":
        //        dent3Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent4":
        //        dent4Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent5":
        //        dent5Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent6":
        //        dent6Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent7":
        //        dent7Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent8":
        //        dent8Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent9":
        //        dent9Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent10":
        //        dent10Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent11":
        //        dent11Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent12":
        //        dent12Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent13":
        //        dent13Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;
        //    case "Dent14":
        //        dent14Counter++;
        //        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f);
        //        break;

        //}

        if (dent1Counter >= 5 && dent2Counter >= 5 && dent3Counter >= 5 && dent4Counter >= 5 && dent5Counter >= 5 && dent6Counter >= 5 && dent7Counter >= 5 && dent8Counter >= 5 && dent9Counter >= 5 && dent10Counter >= 5 && dent11Counter >= 5 && dent12Counter >= 5 && dent13Counter >= 5 && dent14Counter >= 5)
        {
            hasWin = true;
            if (canPlayAudio)
            {
                //AudioManager.Instance.PlayAudio(Audio.BTD_WIN);
                canPlayAudio = false;
            }
            //Voir Saut de clope/BabyClope
        }
    }

}
