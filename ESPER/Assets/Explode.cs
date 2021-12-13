using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private int explosiveDamage = 70;
    public AudioClip explosionSound;
    public GameObject explosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AiBehaviour target = other.GetComponent<AiBehaviour>();
            if (target != null)
            {
                explosion.SetActive(true);
                target.TakeDamage(explosiveDamage);
                //Destroy(gameObject);
            }
        }
    }
}
