using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour {

	public static int n = 4;
	public static List<int>[] points = new List<int>[n];
	public static GameObject[] gms = new GameObject[n];

	public GameObject[] gmss = new GameObject[n];

	List<List<int>> paths = new List<List<int>>();

	int[] vis = new int[n];
	int num = 0;
	int p1, p2;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < n; i++) {
			points[i] = new List<int>();
		}
		conPoint (0, 1);
		conPoint (1, 2);
		conPoint (2, 3);

		List<int> kj = gps (0,3);
		Debug.Log ("Kage" + kj.Count);
		foreach (int i in kj) {
			Debug.Log(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void conPoint(int p1, int p2) {
		if (p1 == p2) {
			return;
		}
		points [p1].Add (p2);
		points [p2].Add (p1);
	}

	public List<int> gps(int p1, int p2) {
		p1 = this.p1;
		p2 = this.p2;
		for (int i = 0; i < n; i++) {
			vis[i] = -1;
		}
		num = 0;
		dfs (p1);
		return findPath (p2);
	}

	void dfs(int k) {
		if (vis[k] != -1) {
			return;
		}
		num++;
		vis[k] = num;
		foreach (int w in points[k]) {
			dfs (w);
		}
	}

	List<int> findPath(int v) {
		if (vis [v] == -1) {
			Debug.Log ("if 1");
			return new List<int> ();
		}
		if (vis[v] == 1) {
			Debug.Log ("if 2");
			List<int> k = new List<int>();
			k.Add(v);
			return k;
		}
		foreach (int w in points[v]) {
			if (vis[w] < vis[v]) {
				Debug.Log ("if 3");
				List<int> k = new List<int>();
				k.Add(v);
				k.AddRange(findPath(w));
				return k;
			}
		}
		return null;
	}
}
