using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public int wallah;
    
    GameObject obj_dummy;
    private Human dummy_human;
    // Use this for initialization
    void Start ()
    {
	    for(int iii = 0; iii <= wallah; ++iii)
        {
            obj_dummy = new GameObject("Wallah" + iii);
            obj_dummy.AddComponent<SpriteRenderer>();
            obj_dummy.AddComponent<Human>();            
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    
}
