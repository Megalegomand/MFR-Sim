using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour {

	public static int n = 4;

    // Liste med forbindelser
	public static List<int>[] points = new List<int>[n];
	public static GameObject[] gms = new GameObject[n];
    public static List<int> houses = new List<int>();

	//public GameObject[] gmss;

    public GameObject stuff;

	static List<List<int>> paths = new List<List<int>>();

    // Liste af punkter der er besøgt
	static int[] vis = new int[n];
    
    // Nummeret som bliver givet til punkterne (L i flowdiagrammet)
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

    // Funktionen der kobler dfs og findPath sammen
	public static List<int> gps(int p1, int p2) {
        // Dette loop restarter listen af besøgte steder
		for (int i = 0; i < vis.Length; i++) {
			vis[i] = -1;
		}
        // Numeret som punkterne for sættes til 0 (L i flowdiagrammet)
		num = 0;
        // Der bliver kørt en dybde først søgning fra punktet p2 (B i flowdiagrammet)
		ripple_dfs(p2);
        // Herefter køres findPath der finder en vej fra p1 (A) til p2 (B)
		return findPath (p1);
	}

    // Dybde Først Søgning fra punktet k (B i flowdiagrammet)
	static void dfs(int k) {
        // Check at punktet ikke har været besøgt, hvis det har så stop funktionen
		if (vis[k] != -1) {
			return;
		}
        // Læg 1 til L
		num++;
        // Giv det nuværende punkt et nummer
		vis[k] = num;
        // Kør igennem alle punkterne omkring det nuværende punkt
		foreach (int w in points[k]) {
            // Kør en Dybde Først Søgning fra alle punkter omkring det nuværende punkt
			dfs (w);
		}
	}

    static void ripple_dfs(int punkt, int rippleNr = 1) {
        // Check at punktet ikke har været besøgt, eller har et lavere tal end det forrige
        if (vis[punkt] != -1 && vis[punkt] < rippleNr) {
            return;
        }
        // Giv det nuværende punkt et nummer
        vis[punkt] = rippleNr;
        rippleNr++;
        // Kør igennem alle punkterne omkring det nuværende punkt
        foreach (int i in points[punkt]) {
            // Kør en Dybde Først Søgning fra alle punkter omkring det nuværende punkt
            ripple_dfs(i, rippleNr);
        }
    }

    // Find en vej fra p1/v (A) til p2 (B)
    static List<int> findPath(int v) {
        // Hvis punktet man prøver at komme hen til ikke er besøgt
        // så er der ikke en vej til punktet
        // Derfor returneres en tom liste
		if (vis [v] == -1) {
			return new List<int> ();
		}
        // Hvis punktet har tallet 1 så er punktet distinationen
        // Vejen til punktet er derfor selve punktet
		if (vis[v] == 1) {
			List<int> k = new List<int>();
			k.Add(v);
			return k;
		}
        // Gå igennem alle punkter omkring punktet
		foreach (int w in points[v]) {
            // Hvis de nye punkt har en mindre værdi en det nuværende køres koden
			if (vis[w] < vis[v]) {
                // Der laves en tom liste
				List<int> k = new List<int>();
                // Det nuværende punkt tilføjes
				k.Add(v);
                // Vejen videre fra dette punkt tilføjes
				k.AddRange(findPath(w));
                // Dette returneres
				return k;
			}
		}
        // Hvis alt går galt så returner ingenting
		return null;
	}
}
