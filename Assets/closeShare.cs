using UnityEngine;
using System.Collections;

public class closeShare : MonoBehaviour {
    public GameObject shareTwitter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (shareTwitter.active && Input.GetMouseButtonDown(0))
        {
            Debug.Log(this.transform.name);
            shareTwitter.active = false;
        }
	}
}
