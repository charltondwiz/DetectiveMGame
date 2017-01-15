using UnityEngine;
using System.Collections;

public class limitRotation : MonoBehaviour {

    public Rigidbody2D rigid;
    public int limitAngleA;
    public int limitAngleB;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.eulerAngles.z < limitAngleA) {
            transform.eulerAngles = new Vector3(0,0,limitAngleA);
            rigid.angularVelocity = 0;
        }

        if(transform.eulerAngles.z > limitAngleB) {
            transform.eulerAngles = new Vector3(0, 0, limitAngleB);
            rigid.angularVelocity = 0;
        }
	}
}
