using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {
    // NEEDS AICONTROLLER PARENT TO WORK
    public Animator anim;
    public int health;
    public bool isAI;
    public bool isPlayer;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isAI) {
            health = GetComponentInParent<AIController>().health;
        }else if (isPlayer) {
            health = GetComponentInParent<PlayerController>().health;
        }
        anim.SetInteger("health", health);
        if (health < 1) {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else {
            GetComponentInParent<SpriteRenderer>().enabled = true;
        }
	}

    
}
