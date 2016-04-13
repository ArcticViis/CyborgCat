using UnityEngine;
using System.Collections;

namespace Werecat
{
    public class bulletController : MonoBehaviour
    {

        public float muzzleVelocity = 300f;
        public float lifeTime = 4f;
        public float damage = 0;

        void Update()
        {
            float _update = Time.deltaTime;
            RaycastHit _rhit;

            if (Physics.Raycast(transform.position, transform.forward, out _rhit, muzzleVelocity * _update))
            {
                Debug.Log(_rhit);
                Debug.Log("Destroy");
                if (_rhit.collider.tag == "Enemy" || _rhit.collider.tag == "Player")
                {
                    Damage(_rhit.collider.gameObject);
                }
                Destroy(gameObject);

            }

            transform.position += transform.forward * muzzleVelocity * _update;
            damage -= damage * _update * 1.2f;
            lifeTime -= _update;
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void Damage(GameObject _target)
        {
            if (_target.tag == "Enemy")
            {
                _target.GetComponent<Enemy>().TakeDamage(damage);
            }
            if (_target.tag == "Player")
            {
                _target.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }
    }
}