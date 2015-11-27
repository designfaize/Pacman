using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameHelper : MonoBehaviour {
    public List<GameObject> ghosts;
    private static List<GameObject> _ghosts;
	// Use this for initialization
	void Start () {
        _ghosts = ghosts;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public static void stopAllGhosts()
    {
        foreach (GameObject ghost in _ghosts)
        {
            ghost.GetComponent<ghostMovement>().stopGhost();
        }
    }
}
