using UnityEngine;
using System.Collections;

public class GrapplingRope : MonoBehaviour {


    public Rigidbody2D rigid;
    public float limitAngularSpeed;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
        
    }
	// Update is called once per frame
	void Update () {
	    if(rigid.angularVelocity > limitAngularSpeed) {
            rigid.angularVelocity = 0;
        }

        if(GetComponentInChildren<Rigidbody2D>().angularVelocity > limitAngularSpeed) {
            GetComponentInChildren<Rigidbody2D>().angularVelocity = 0;
        }
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Grapple" && GetComponent<HingeJoint2D>().Equals(null)) {
            Debug.Log("touched grapple");
            HingeJoint2D hinge = gameObject.AddComponent<HingeJoint2D>();
            hinge.connectedBody = coll.GetComponent<Rigidbody2D>();
            JointAngleLimits2D hingelimits = hinge.limits;
            hinge.useLimits = true;
            hinge.limits = new JointAngleLimits2D();
            hingelimits.min = 0;
            hingelimits.max = 180;
            hinge.anchor = new Vector2(0.2435164f, 0.2113019f);
            gameObject.transform.SetParent(coll.gameObject.transform);
        }
    }

}
