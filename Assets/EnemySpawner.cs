using UnityEngine;
using System.Collections;
namespace Werecat {
    public class EnemySpawner : MonoBehaviour {
        public GameObject prefab;
        public EnemyCommunications comms;
        private GameObject instance;


        // Use this for initialization
        void Start() {
            comms = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyCommunications>();
            instance = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            comms.RegisterEnemy(instance);
            Invoke("Spawn", 3f);
        }
        
        void Spawn()
        {
            instance.SetActive(true);
        }
    }
}