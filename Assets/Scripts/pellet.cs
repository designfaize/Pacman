using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pellet : MonoBehaviour {
    private UnityEngine.UI.Text scorefieldComponent;
    void Start()
    {
    }
    void OnTriggerEnter(Collider co) {
        if (co.name == "pacman")
        {
            score.addToScore("pellet");
            Destroy(gameObject);
        }
    }
}