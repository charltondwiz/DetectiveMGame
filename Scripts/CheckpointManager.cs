using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour {
    public GameObject[] Checkpoints;
    public PlayerController player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void UpdateCheckpoints() {
        for (int i = 0; i < Checkpoints.Length; i++) {
            if (Checkpoints[i] != player.currentCheckpoint) {
                Checkpoints[i].GetComponent<Animator>().SetBool("CurrentCheckPoint", false);
            }
        }
    }
}
