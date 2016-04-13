using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{

    public int wallah_hus;
    public int wallah_human;

    public Transform human;
    public Transform house;

    // Use this for initialization
    void Start()
    { 
        make_bitches("Human", wallah_human);
        make_bitches("House", wallah_hus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void make_bitches(string bitches, int wallah)
    {
        GameObject obj_dummy;
        if (bitches == "Human")
        {
            for (int iii = 0; iii < wallah; ++iii)
            {
                /*obj_dummy = new GameObject(bitches + iii);
                obj_dummy.AddComponent<SpriteRenderer>();
                obj_dummy.AddComponent(System.Type.GetType(bitches));*/
                obj_dummy = Instantiate(human).gameObject;               
            }
        }
        else if(bitches == "House")
        {
            for (int iii = 0; iii < wallah; ++iii)
            {
                /*obj_dummy = new GameObject(bitches + iii);
                obj_dummy.AddComponent<SpriteRenderer>();
                obj_dummy.AddComponent(System.Type.GetType(bitches));*/
                obj_dummy = Instantiate(house).gameObject;
            }
        }
    }


    void delete_bitches(string bitches)
    {
        GameObject[] chala = GameObject.FindGameObjectsWithTag(bitches);
        for (int iii = 0; iii < chala.Length; ++iii)
            Destroy(chala[iii]);
    }
}
