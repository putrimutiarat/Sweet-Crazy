﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Manager.Instance.WasGameOver) {
            Destroy(this.gameObject);
        }
	}
}