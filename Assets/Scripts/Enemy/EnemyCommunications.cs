using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCommunications : MonoBehaviour {

    public GameObject player;
    public Vector3 playerSpot;

    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    private 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RegisterEnemy(GameObject _regist)
    {
        enemies.Add(_regist);
    }

    public void PlayerSpotted(Vector3 position, Vector3 origin)
    {
        foreach (GameObject enemy in enemies)
        {
            if(Vector3.Distance(position,origin) < 100)
            {
                // go to help;
            }
        }
    }
}
