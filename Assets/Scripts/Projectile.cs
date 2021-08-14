using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float projectileRotationSpeed = 3f;
    [SerializeField] int projectileDamageAmount = 10;
    [SerializeField] GameObject hit;


    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed, Space.World);
        transform.Rotate(new Vector3(0,0,-1) * Time.deltaTime * projectileRotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.TakeDamage(projectileDamageAmount);
            var vfx = Instantiate(hit, transform.position, transform.rotation);
            Destroy(vfx, 1f);
            Destroy(gameObject);
        }
    }
}
