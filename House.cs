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

    public int number;

    // Use this for initialization
    public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

	void FixedUpdate() {
        if (humans.Count != 0) {
            if (Random.Range(0, ctgo) < 1) {
                int k = (int)(Random.Range(0, humans.Count - 1));
                humans[k].SetActive(true);
                humans[k].GetComponent<Human>().moving = false;
                humans[k].GetComponent<Human>().cp = number;
                humans.RemoveAt(k);
            }
        }
	}

	public void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.GetComponent<Human> () != null) {
            if (col.GetComponent<Human>().moving) {
                col.gameObject.SetActive(false);
                humans.Add(col.gameObject);
            }
		}
	}
}
