using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : MonoBehaviour {
    int lifePlayer = 5;
    public Texture text;
    //Vector3Int BombaInicial = gameObject.transform.position;

    void OnGUI()
    {
        GUI.Label(new Rect(1, 5, 90, 25), "Player Life: " + lifePlayer);
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.gameObject.transform.Translate(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.gameObject.transform.Translate(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.gameObject.transform.Translate(0, 0, -1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.Translate(0, 0, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateBomb();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BoC")
        {
            ChangeLifePlayer();
            Destroy(other.gameObject);
        }

        if (lifePlayer == 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeLifePlayer()
    {
        lifePlayer = lifePlayer - 1;
    }

    private GameObject GenerateBomb()
    {
        GameObject bombP = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bombP.GetComponent<Renderer>().material.color = Color.blue;
		bombP.transform.position = gameObject.transform.position;
		bombP.AddComponent<Rigidbody>();
		bombP.GetComponent<Collider>().isTrigger = true;
		bombP.GetComponent<Rigidbody>().useGravity = false;
		bombP.transform.localScale = new Vector3(.3f, .3f, .3f);
		bombP.name = "BoP";
		return bombP;
    }
}
