using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float destroyDelay = 1f;
    public Camera cam;
    public ParticleSystem flash;
    public GameObject impactEffect;
    public float force = 75f;
    public float fireRate = 15f;
    private float _timeToFire;
    private void Shoot()
    {
        flash.Play();
        FindObjectOfType<AudioPlayer>().PlaySound();
        var transform1 = cam.transform;
        RaycastHit hit;
        if (!Physics.Raycast(transform1.position, transform1.forward, out hit, range)) return;
        var enemy = hit.transform.GetComponent<Enemies>();
        if (enemy != null)
        {
            enemy.Damage(damage);
        }

        var impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, destroyDelay);

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * force);
        }
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= _timeToFire)
        {
            _timeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
}
