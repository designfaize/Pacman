using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class score : MonoBehaviour {
    private static UnityEngine.UI.Text scorefieldComponent;
    private int _score;
    public int pellet_value;
    private static Dictionary<string,int> items = new Dictionary<string, int>();
    // Use this for initialization
    void Start() {
        GameObject scoreField = GameObject.Find("Score");
        Debug.Log("scoreField: " + scoreField.ToString());
        scorefieldComponent = scoreField.GetComponent<Text>();
        score.items.Add("pellet", pellet_value);
    }
    // Update is called once per frame
    void Update() {
    }
    
    public static void addToScore(string type)
    {
        int currentScore = int.Parse(scorefieldComponent.text);
        scorefieldComponent.text = (currentScore + score.items[type]).ToString();
    }
}
