using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class flag_script : MonoBehaviour {

    public Animator anim;
    public string LevelToLoad;
    private bool Broken;
    private PlayerController player;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnTriggerStay2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            if(!Broken && player.punching) {
                Debug.Log("punched flag");
                Broken = true;
                StartCoroutine("LoadNextLevel");
            }
        }
    }
    IEnumerator LoadNextLevel() {

        anim.SetBool("broken", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(LevelToLoad);
    }
}
