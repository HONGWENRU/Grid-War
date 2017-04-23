using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreatePickups : MonoBehaviour {

    public GameObject pickup;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), 0);
        GameObject clone = Instantiate(pickup, position, transform.rotation);
    }
}
