using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

    public bool isFalling;
    private GameMaster gm;
    public AudioClip jumpClip;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update () {
        DetectMouse();
        DetectTouch();
        Move();
	}

    void DetectTouch()
    {
        Touch t;
        if(Input.touchCount > 0)
        {
            t = Input.GetTouch(0);
            if(t.phase == TouchPhase.Began)
            {
                Jump();
            }

        }
    }

    void DetectMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            //Debug.Log("Mouse Button Released");
        }
    }

    private void Jump()
    {
        if (isFalling)
        {
            return;
        }
        gm.aSource.PlayOneShot(jumpClip,1);
        Rigidbody2D rigid = this.GetComponent<Rigidbody2D>();
        Vector2 newVelocity = new Vector2(rigid.velocity.x, gm.jumpHeight);
        rigid.velocity = newVelocity;
        isFalling = true;
    }

    private void Move()
    {
        transform.Translate(Vector3.right * gm.speed * Time.deltaTime);
    }

    void OnCollisionStay2D()
    {
        isFalling = false;
    }


}
