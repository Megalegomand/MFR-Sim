using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	ArrayList humans = new ArrayList();
	[Tooltip("Chance to get out")]
	public int ctgo = 500;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (Random.Range (0, ctgo) < 1) {
			humans[Random.Range(0,humans.Count)]
		}
	}

	void OnTriggerEnter(Collider2D col) {
		if (col.gameObject.GetComponent<Human> () != null) {
			col.enabled = false;
			humans.Add(col.gameObject);
		}
	}
}
