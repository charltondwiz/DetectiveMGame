using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {
    public float ParticleTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, ParticleTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
