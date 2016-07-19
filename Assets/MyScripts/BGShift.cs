using UnityEngine;
using System.Collections;

public class BGShift : MonoBehaviour {

    private GameMaster gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        float width = ((BoxCollider2D)collider).size.x;
        Vector3 pos = collider.transform.position;
        pos.x += width * gm.BGMultiplier;
        if (collider.transform.tag == "BG1")
        {
            collider.transform.position = pos;
        }

        if (collider.transform.tag == "BG2")
        {
            collider.transform.position = pos;
        }

    }
}
