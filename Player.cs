using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject dp;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {




        }
        transform.position += new Vector3(5 * Input.GetAxis("Horizontal"), 5 * Input.GetAxis("Vertical"), 0) * Time.deltaTime;

    }
private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == dp){




        }     
    }
}
