using UnityEngine;
using System.Collections;

public class AddPowerUpOnCollision : MonoBehaviour {

    public PlayerController player;
    public string UpgradeName;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            GameObject UpgradeName = Instantiate(gameObject,Vector2.zero,transform.rotation) as GameObject;
            UpgradeName.GetComponent<SpriteRenderer>().enabled = false;
            player.AddPowerUp(UpgradeName);
            UpgradeName.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
