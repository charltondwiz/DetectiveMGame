using UnityEngine;
using System.Collections;

public class bullet_script : MonoBehaviour {


    private Rigidbody2D rigid;
    public float force;
    public PlayerController player;
    public float directionOfBullet;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        directionOfBullet = (Mathf.Abs(player.transform.localScale.x)/player.transform.localScale.x);
	}
	
	// Update is called once per frame
	void Update () {
        rigid.velocity = new Vector2(force*directionOfBullet, 0);
	}
}
