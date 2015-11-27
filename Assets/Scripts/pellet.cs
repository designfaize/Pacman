using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pellet : MonoBehaviour {
    private UnityEngine.UI.Text scorefieldComponent;
    private GameObject pellets;
    void Start()
    {
        pellets = GameObject.Find("level1Pellets");
    }
    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "pacman")
        {
            score.addToScore("pellet");
            Destroy(gameObject);
            if (pellets.GetComponentsInChildren<pellet>().Length == 1)
            {
                Debug.Log("All pellets eaten");
            }
        }
    }
}