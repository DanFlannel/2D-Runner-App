using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

    public void Awake()
    {
        DontDestroyOnLoad(this);
        GameObject[] gos = GameObject.FindGameObjectsWithTag(this.transform.tag);
        if (gos.Length > 1)
        {
            for(int i = 0; i < gos.Length; i++)
            {
                if(this.transform.name == gos[i].transform.name)
                {
                    Debug.Log("Found a duplicate, destroying : " + this.gameObject.name + ":" + gos[i].name);
                    Destroy(gameObject);
                }
            }
        }
    }
}
