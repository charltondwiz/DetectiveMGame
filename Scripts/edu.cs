using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class edu : MonoBehaviour {

    public int NumberOfRows;
    public string[] NameOfRows;

    public string[] FirstRow;

    public string[] SecondRow;

    public string[] ThirdRow;

    public string totalWords;

    public int ThirdRowBreak=0;

    public int SecondCurrentNumber = 0;
    public int ThirdCurrentNumber=0;

    void Start () {
        for (int i = 0; i < FirstRow.Length; i++) {
            for (int j = 0; j < SecondRow.Length; j++) {
                while (ThirdCurrentNumber < ThirdRow.Length) {

                    Debug.Log(FirstRow[i] + SecondRow[j] + ThirdRow[ThirdCurrentNumber]);
                    ThirdCurrentNumber++;
                }
                ThirdCurrentNumber = 0;
            }
        }
    }
	
	
	void Update () {
	
	}

}
