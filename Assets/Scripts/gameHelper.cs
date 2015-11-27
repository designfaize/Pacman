using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameHelper : MonoBehaviour {
    public List<GameObject> ghosts;
    public GameObject playAgainButton;
    private static List<GameObject> _ghosts;
    private static int lives = 0;
	// Use this for initialization
	void Start () {
        _ghosts = ghosts;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void stopAllGhosts()
    {
        foreach (GameObject ghost in _ghosts)
        {
            ghostMovement ghostController = ghost.GetComponent<ghostMovement>();
            ghostController.stopGhost();
            ghostController.resetGhost();
        }
        if (lives == 0)
        {
            playAgainButton.SetActive(true);
        }
    }
}
