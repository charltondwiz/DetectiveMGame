using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public PlayerController player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -7);
    }

}
