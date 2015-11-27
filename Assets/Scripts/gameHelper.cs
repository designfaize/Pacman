using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class gameHelper : MonoBehaviour {
    public List<GameObject> ghosts;
    public Button playAgainButton;
    public GameObject pellets;
    private static Button _playAgainButton;
    private static List<GameObject> _ghosts;
    private static int _lives = 0;
    private static PacmanMove _pacman;
    private static int level = 1;
    // Use this for initialization
	void Start () {
        _ghosts = ghosts;
        _playAgainButton = playAgainButton;
        _pacman = GameObject.Find("pacman").GetComponent<PacmanMove>();
        _playAgainButton.gameObject.SetActive(false);
        _playAgainButton.onClick.AddListener(delegate
        {
            restartGame();
        });
        
    }

    // Update is called once per frame
    void Update () {
	
	}
    public static void stopAllGhosts()
    {
        foreach (GameObject ghost in _ghosts)
        {
            ghostMovement ghostController = ghost.GetComponent<ghostMovement>();
            ghostController.stopGhost();
        }
        _playAgainButton.gameObject.SetActive(true);
    }
    public static void restartGame()
    {
        foreach (GameObject ghost in _ghosts)
        {
            ghostMovement ghostController = ghost.GetComponent<ghostMovement>();
            ghostController.resetGhost();
            
        }
        _playAgainButton.gameObject.SetActive(false);
        _pacman.resetPacman();

        Destroy(GameObject.Find("level" + level.ToString() + "Pellets"));
        GameObject pellets = Instantiate(Resources.Load("level" + level.ToString() + "Pellets", typeof(GameObject))) as GameObject;
        pellets.transform.SetParent(GameObject.Find("Maze").transform,false);
    }
}
