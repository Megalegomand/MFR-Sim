using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

	List<GameObject> humans = new List<GameObject>();
	[Tooltip("Chance to get out")]
	public int ctgo = 500;
	public int infectChance = 100;
	public int maxPerson = 10;
	public int distWeight = 10;

	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

	void FixedUpdate() {
		if (Random.Range (0, ctgo) < 1) {
			humans[(int)(Random.Range (0,humans.Count-1))].SetActive(true);

		}
	}

	public void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.GetComponent<Human> () != null) {
			col.gameObject.SetActive (false);
			humans.Add(col.gameObject);
		}
	}
}
