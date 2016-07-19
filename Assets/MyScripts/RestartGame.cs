using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

    private GameMaster gm;
    public bool restart;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
