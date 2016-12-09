using UnityEngine;
using System.Collections;

public class splash : MonoBehaviour {
    int a;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("intGameOver", 0);
        a = 0;
	}
	
	// Update is called once per frame
	void Update () {
        a++;
        if (a > 100)
        {
            Application.LoadLevel(1);
            PlayerPrefs.SetInt("sound", 1);
        }
	}
}
