using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rigid;
    public float speedX;
    public float speedY;
    public float speedx;
    public float speedy;
    public float jumpForce;
    public float gravityScale;
    public bool isGrounded;
    public bool punching;
    public Animator anim;
    public HotBarManager hotbar;
    public int health;
    public GameObject laserDeathParticles;
    public bool currentlyDead;
    public GameObject currentCheckpoint;
    public CheckpointManager checkpoint;
    public GameObject pistol_bullet;
    public float gunX_offset;
    public float gunY_offset;
    public bool shooting;
    public GameObject[] PowerUps;
    public Image[] PowerUpsHotbar;
    public int maxPowerUps;
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hotbar = FindObjectOfType<HotBarManager>();
        health = 100;
        checkpoint = FindObjectOfType<CheckpointManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health < 1) {
            if (!currentlyDead) {
                StartCoroutine("Death");
                currentlyDead = true;
            }
        }
        if (hotbar.currentHotBarWeapon=="pistol") {
            anim.SetBool("gun", true);
        }else {
            anim.SetBool("gun", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            speedX = speedx;
            gameObject.transform.localScale = new Vector3(100, transform.localScale.y, transform.localScale.z);
        } else if (Input.GetKey(KeyCode.A))
        {
            speedX = -speedx;
            gameObject.transform.localScale = new Vector3(-100, transform.localScale.y, transform.localScale.z);
        } else
        {
            speedX = 0;
        }

    if (Input.GetButtonDown("Fire1")) {
            if (hotbar.currentHotBarWeapon == "fist") {

                StartCoroutine("punch");
            } else if (hotbar.currentHotBarWeapon == "pistol") {
                if (!shooting) {
                    StartCoroutine("gun");
                    shooting = true;
                }
            }

        }
    
    
        if (Mathf.Abs(speedX) > 0.3) {
            anim.SetBool("walking", true);
        }else {
            anim.SetBool("walking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.AddForce(new Vector2(0, jumpForce),ForceMode2D.Force);
        }

        if (isGrounded)
        {
            rigid.gravityScale = 1;
        }
        else
        {
            if (rigid.gravityScale < 100)
            {
                rigid.gravityScale *= 1.8f;
            }
        }



        anim.SetBool("grounded", isGrounded);

        rigid.velocity = new Vector2(speedX, rigid.velocity.y);
    }


    public IEnumerator punch() {
        anim.SetBool("punch", true);
        punching = true;
        yield return new WaitForSeconds(0.176f);
        punching = false;
        anim.SetBool("punch", false);
    }
    public IEnumerator gun() {
        anim.SetBool("shootgun", true);
        Instantiate(pistol_bullet, new Vector3(transform.position.x + gunX_offset, transform.position.y + gunY_offset, 1), transform.rotation);
        yield return new WaitForSeconds(0.03f);
        anim.SetBool("shootgun", false);
        yield return new WaitForSeconds(0.3f);
        shooting =false;
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Ground") {
            isGrounded = true;
        }
        if(coll.gameObject.tag == "Checkpoint") {

            coll.GetComponent<Animator>().SetBool("CurrentCheckPoint", true);
            currentCheckpoint = coll.gameObject;
            checkpoint.UpdateCheckpoints();
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }

    IEnumerator Death() {
        Instantiate(laserDeathParticles, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
        //rigid.velocity = Vector2.zero;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(2);
        this.enabled = true;
        transform.position = currentCheckpoint.transform.position;
        rigid.constraints = RigidbodyConstraints2D.None;
        GetComponent<SpriteRenderer>().enabled = true;
        currentlyDead = false;
        health = 100;

    }

    public void AddPowerUp(GameObject Powerup) {
        for(int i = 0; i < PowerUps.Length; i++) {
            if (PowerUps[i] == null) {
                PowerUps[i] = Powerup;
                PowerUpsHotbar[i].sprite = Powerup.GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }
    }
}
