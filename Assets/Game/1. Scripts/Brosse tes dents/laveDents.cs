using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class laveDents : MonoBehaviour
{
    private readonly List<int> _dents = new();

    private bool _canPlayAudio = true;

    private void Start()
    {
        // init the list of dents with 0
        for (var i = 0; i < 14; i++)
        {
            _dents.Add(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Dent")) return;

        print(other.gameObject.GetComponent<SpriteRenderer>().color.a);
        var dentTouched = other.gameObject.name;

        // if the dent is not in the list, return
        if (_dents.Contains(int.Parse(dentTouched[4..]))) return;

        // increment the counter of the touched dent, -1 because the dents are numbered from 1 to 14
        _dents[int.Parse(dentTouched[4..]) - 1]++;

        // var alpha = other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f;
        // other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
        var alpha = other.gameObject.GetComponent<SpriteRenderer>().color.a - 0.2f;
        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);

        if (_dents.All(dent => dent < 5)) return;

        // Win
        if (_canPlayAudio)
        {
            // AudioManager.Instance.PlayAudio("Victoire Dents");
            _canPlayAudio = false;
        }
        
        // join the list of dents with a comma
        print(string.Join(", ", _dents));
        print("win");
        GameStats.Instance.Win = true;
    }
}