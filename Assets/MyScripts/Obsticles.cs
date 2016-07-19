using UnityEngine;
using System.Collections;

public class Obsticles : MonoBehaviour {

    public GameObject[] gos;

    private float timer;
    private GameMaster gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }


    // Update is called once per frame
    void Update () {
        Move();
        Timer();
	}

    private void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(gm.obstilceMin, gm.obsticleMax);
            ObsticleMaker();
        }

    }

    private void ObsticleMaker()
    {
        int rnd = Random.Range(0, gos.Length);
        GameObject clone = Instantiate(gos[rnd], transform.position, Quaternion.identity) as GameObject;
        float xx = Random.Range(1, 5);

    }

    private void Move()
    {
        transform.Translate(Vector3.right * gm.speed * Time.deltaTime);
    }
}
