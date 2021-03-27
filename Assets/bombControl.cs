using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombControl : MonoBehaviour {
    GameObject controllingPlayer;
    public GameObject arrow;
    public bool isInHand;
    Rigidbody2D rb;
    // Use this for initialization
    void Start ()
    {   rb = GetComponent<Rigidbody2D>();
        isInHand = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("up"))
        {
            transform.Rotate(0, 0, 3f);
        }
        if (Input.GetKey("down"))
        {
            transform.Rotate(0, 0, -3f);
        }
        if (Input.GetKey("space"))
        {
            shoot();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player (2)")
        {
            if (!isInHand)
            {
                controllingPlayer = GameObject.Find("player (2)");
                transform.position = new Vector3(controllingPlayer.transform.position.x,
                                                 controllingPlayer.transform.position.y,
                                                 transform.position.z);
                isInHand = true;
                rb.velocity = new Vector2(0, 0);
                arrow.GetComponent<Renderer>().enabled = true;
            }
        }
    }
    void shoot()
    {
        rb.velocity = new Vector2(5f * Mathf.Cos(transform.rotation.eulerAngles.z*Mathf.PI/180f), 5f * Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180f));
        isInHand = false;
        arrow.GetComponent<Renderer>().enabled = false;
    }
}
