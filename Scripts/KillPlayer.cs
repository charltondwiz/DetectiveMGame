using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public int damageToPlayer;
    public PlayerController player;
    public bool DamageOnStay;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Player") {
            player.health -= damageToPlayer;
            Debug.Log("touched player");
        }
    }
    void OnTriggerStay2D(Collider2D coll) {
        if (DamageOnStay) {
            if (coll.gameObject.tag == "Player") {
                player.health -= damageToPlayer;
                Debug.Log("touched player");
            }
        }
    }

}
