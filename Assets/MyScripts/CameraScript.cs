using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private GameMaster gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        transform.Translate(Vector3.right * gm.speed * Time.deltaTime);
    }
}
