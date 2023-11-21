using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 10f;
    [SerializeField]
    private float bulletDamage = 20f;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private GameObject bulletGFX;

    private bool audioIsPlayed;
    Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(bulletGFX);
        //bulletGFX.SetActive(false);

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(bulletDamage);
        }

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (!audioIsPlayed)
            {
                Destroy(collision.gameObject);
                explosionPrefab.SetActive(true);
                audioSource.pitch = Random.Range(.6f, .9f);
                audioSource.Play();
                audioIsPlayed = true;
            }
        }

        else if (!audioIsPlayed)
        {
            audioSource.pitch = Random.Range(.6f, .9f);
            audioSource.Play();
            audioIsPlayed = true;
            explosionPrefab.SetActive(true);

        }
        collider.enabled = false;
    }
}
