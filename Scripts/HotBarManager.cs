using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HotBarManager : MonoBehaviour {

    public int CurrentHotBarNumber;
    public int LeftHotBarNumber;
    public int RightHotBarNumber;
    public Sprite[] HotBarImages;
    public Image LeftHotbar;
    public Image CenterHotBar;
    public Image RightHotBar;
    public Sprite Nothing;
    public string[] HotBarWeaponNames;
    public string currentHotBarWeapon;
	// Use this for initialization
	void Start () {
        CurrentHotBarNumber = 1;
        CenterHotBar.sprite = HotBarImages[CurrentHotBarNumber];
        LeftHotbar.sprite = HotBarImages[LeftHotBarNumber];
        RightHotBar.sprite = HotBarImages[RightHotBarNumber];
        //HotBarImages[HotBarImages.Length] = Nothing;
    }
	
	// Update is called once per frame
	void Update () {
        currentHotBarWeapon = HotBarWeaponNames[CurrentHotBarNumber];
        if (CurrentHotBarNumber > 0) {
            LeftHotBarNumber = CurrentHotBarNumber - 1;
        }else {
            LeftHotBarNumber = 0;
        }
        RightHotBarNumber = CurrentHotBarNumber + 1;

        if (Input.GetKeyDown(KeyCode.E) && CurrentHotBarNumber<HotBarImages.Length && RightHotBar.sprite!=Nothing) {
            CurrentHotBarNumber++;
        }

        if (Input.GetKeyDown(KeyCode.Q) && CurrentHotBarNumber>1) {
            CurrentHotBarNumber--;
        }

        CenterHotBar.sprite = HotBarImages[CurrentHotBarNumber];
        LeftHotbar.sprite = HotBarImages[LeftHotBarNumber];
        RightHotBar.sprite = HotBarImages[RightHotBarNumber];


    }
}
