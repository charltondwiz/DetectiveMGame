using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpHotbar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(GetComponent<Image>().sprite == null) {
            GetComponent<Image>().color = new Color(255,255,255,0) ;
        }else {
            GetComponent<Image>().color = new Color(255,255,255,255);
        }
	}
}
