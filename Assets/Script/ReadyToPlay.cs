using UnityEngine;
using System.Collections;

public class ReadyToPlay : MonoBehaviour {
    Sprite temp;
    Vector3 myPos;
	// Use this for initialization
	void Start () {
        temp = GetComponent<SpriteRenderer>().sprite;
        myPos = this.transform.position;
        this.transform.position = new Vector3(100, 100, 100);
        GetComponent<SpriteRenderer>().sprite = null;

    }
	
	// Update is called once per frame
	void Update () {
        if (Manager.Instance.ReadyPlay && GetComponent<SpriteRenderer>().sprite == null) {
            GetComponent<SpriteRenderer>().sprite = temp;
            this.transform.position = myPos;
        }
	}
}
