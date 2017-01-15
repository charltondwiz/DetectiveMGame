using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {
    public int health;
    public PlayerController player;
    public Rigidbody2D rigid;
    public bool destroyParts;
    public GameObject[] partToBeDestroyed;
    public bool animator;
    public Animator anim;
    public bool dead;
    public bool ParticlesOnDeath;
    public GameObject DeathParticles;
        
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        rigid = GetComponent<Rigidbody2D>();
        if (animator) {
            anim = GetComponent<Animator>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (health < 1) {
            die();
        }

        if (dead) {
            if (rigid.gravityScale < 1000) {
                rigid.gravityScale += 1;
                rigid.gravityScale *= 1.8f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.name.Contains("bullet")) {
            health -= 15;
            Debug.Log("hit detected");
        }
    }

    void die() {
        if (!dead) {
            //rigid.gravityScale = 5;
            if (destroyParts) {
                for (int i = 0; i < partToBeDestroyed.Length; i++) {
                    Destroy(partToBeDestroyed[i]);
                }
            }
            if (anim) {
                anim.SetBool("destroyed", true);
            }
            // rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<PolygonCollider2D>().isTrigger = false;
            dead = true;
            GameObject particles;
            particles = Instantiate(DeathParticles, transform.position, transform.rotation) as GameObject;
            particles.transform.SetParent(transform);
            particles.transform.localScale = Vector3.one;
            gameObject.tag = "Ground";

        }

    }
}
