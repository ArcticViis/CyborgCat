using UnityEngine;
using System.Collections;

public class SpellController : MonoBehaviour {
    private CharacterController cc;
    private GameObject player;


	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        player = gameObject;
	}
	
	// Update is called once per frame

    void LateUpdate()
    {
        NavMeshHit _hit;
        bool hit = NavMesh.Raycast(player.transform.position + Vector3.up, Camera.main.transform.position + Camera.main.transform.forward * 150, out _hit, 0);


        if (NavMesh.Raycast(player.transform.position + Vector3.up, Camera.main.transform.position + Camera.main.transform.forward * 150, out _hit, 0))
        {
            Blink(_hit.position);
            Debug.Log("hit");
            
        }
        Debug.DrawLine(player.transform.position + Vector3.up, Camera.main.transform.position + Camera.main.transform.forward * 150, hit ? Color.red : Color.green);
    }
    private void Blink(Vector3 _loc)
    {

    }
}
