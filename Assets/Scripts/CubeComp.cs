using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeComp : MonoBehaviour {
    int lifeComp = 5;

    void OnGUI()
    {
		GUI.Label(new Rect(1, 25, 90, 25), "Computer Life: " + lifeComp);
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.gameObject.transform.Translate(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.gameObject.transform.Translate(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.gameObject.transform.Translate(0, 0, 1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.Translate(0, 0, -1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateBomb();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BoP")
        {
            ChangeLifeComp();
            Destroy(other.gameObject);
        }

        if (lifeComp == 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeLifeComp()
    {
        lifeComp = lifeComp - 1;
    }

    private GameObject GenerateBomb()
    {
        GameObject bombComp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bombComp.GetComponent<Renderer>().material.color = Color.red;
		bombComp.transform.position = gameObject.transform.position;
		bombComp.AddComponent<Rigidbody>();
		bombComp.GetComponent<Collider>().isTrigger = true;
		bombComp.GetComponent<Rigidbody>().useGravity = false;
		bombComp.transform.localScale = new Vector3(.3f, .3f, .3f);
		bombComp.name = "BoC";
		return bombComp;
    }
}
