using UnityEngine;
using System.Collections;

public class HttpBegin : MonoBehaviour {
    HttpManager hm = new HttpManager();
    // Use this for initialization
    void Start () {

        hm.getNodeItem();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.R))
        {
            hm.resetNodeColor();
            string a = "";
            for(int i=0; i<225; i++)
            {
                a += "0";
            }
            MapSpawner.nodeColorString = a;
        }
	}
}
