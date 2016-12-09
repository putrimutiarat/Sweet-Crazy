using UnityEngine;
using System.Collections;

public class MakananJatuh : MonoBehaviour {
	public Sprite [] mySprite;
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = mySprite[Random.Range(0, mySprite.Length)];
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -7.09f)
        {
			Destroy(this.gameObject);
		}
	}
}
