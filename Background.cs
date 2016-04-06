using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public static int n = 4;
	public static bool[,] points = new bool[n,n];
	public static GameObject[] gms = new GameObject[n];

	public GameObject[] gmss = new GameObject[n];

	// Use this for initialization
	void Start () {
		addPoint (0, 1);
		addPoint (1, 0);
		addPoint (1, 2);
		addPoint (2, 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addPoint(int p1, int p2) {
		if (p1 == p2) {
			return;
		}
		points[p1,p2] = true;
		points[p2,p1] = true;
	}


}
