using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	ArrayList humans = new ArrayList<GameObject>();
	[Tooltip("Chance to get out")]
	public int ctgo = 500;

	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

	void FixedUpdate() {
		if (Random.Range (0, ctgo) < 1) {
			//humans[(int)(Random.Range (0,humans.Count-1))];

		}
	}

	public void OnTriggerEnter(Collider2D col) {
		if (col.gameObject.GetComponent<Human> () != null) {
			col.enabled = false;
			humans.Add(col.gameObject);
		}
	}
}
