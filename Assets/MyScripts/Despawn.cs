using UnityEngine;
using System.Collections;

public class Despawn : MonoBehaviour {

    private GameMaster gm;
    public float timer;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        timer = gm.despawn;
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy();
        }
	}

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
