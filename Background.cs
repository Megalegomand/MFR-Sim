using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour {

	public static int n = 4;
	public static List<int>[] points = new List<int>[n];
	public static GameObject[] gms = new GameObject[n];
    public static List<int> houses = new List<int>();

	//public GameObject[] gmss;

    public GameObject stuff;

	static List<List<int>> paths = new List<List<int>>();

	static int[] vis = new int[n];
	static int num = 0;

	// Use this for initialization
	void Awake () {
		Time.timeScale = 1;
        /*
        n = gmss.Length;
        gms = new GameObject[n];
        points = new List<int>[n];
        vis = new int[n];
        for (int i = 0; i < gmss.Length; i++) {
            gms[i] = gmss[i];
        }
		for (int i = 0; i < n; i++) {
			points[i] = new List<int>();
		}*/

        n = stuff.transform.childCount;
        gms = new GameObject[n];
        points = new List<int>[n];
        vis = new int[n];
        for (int i = 0; i < stuff.transform.childCount; i++) {
            gms[i] = stuff.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < n; i++) {
            points[i] = new List<int>();
        }

        int kage = 0;
        foreach (GameObject gm in gms) {
            Vector3 pos1 = gm.transform.position + new Vector3(1, 0);
            Vector3 pos2 = gm.transform.position + new Vector3(-1, 0);
            Vector3 pos3 = gm.transform.position + new Vector3(0, 1);
            Vector3 pos4 = gm.transform.position + new Vector3(0, -1);
            int andekage = 0;
            foreach (GameObject check in gms) {
                if (check.transform.position == pos1 || check.transform.position == pos2 || check.transform.position == pos3 || check.transform.position == pos4) {
                    if (check.tag.Equals("Respawn")) {
                        if (gm.GetComponent<House>() != null && check.GetComponent<House>() != null) {
                        } else {
                            points[andekage].Add(kage);
                        }
                    }
                }
                andekage++;
            }
            kage++;
        }

        for (int i = 0; i < gms.Length; i++) {
            if (gms[i].GetComponent<House>() != null) {
                gms[i].GetComponent<House>().number = i;
                houses.Add(i);
            }
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

	public static List<int> gps(int p1, int p2) {
		for (int i = 0; i < n; i++) {
			vis[i] = -1;
		}
		num = 0;
		dfs (p2);
		return findPath (p1);
	}

	static void dfs(int k) {
		if (vis[k] != -1) {
			return;
		}
		num++;
		vis[k] = num;
		foreach (int w in points[k]) {
			dfs (w);
		}
	}

	static List<int> findPath(int v) {
		if (vis [v] == -1) {
			return new List<int> ();
		}
		if (vis[v] == 1) {
			List<int> k = new List<int>();
			k.Add(v);
			return k;
		}
		foreach (int w in points[v]) {
			if (vis[w] < vis[v]) {
				List<int> k = new List<int>();
				k.Add(v);
				k.AddRange(findPath(w));
				return k;
			}
		}
		return null;
	}
}
