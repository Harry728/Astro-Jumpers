using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField] int damage = 100;
    [SerializeField] float gravityDisruptDistance;
    [SerializeField] HealthOMeter healthOMeter = null;

    Ground ground = null;
    int maxHealth = 100;
    int health = 0;

    private void Start()
    {
        if (target == null) {
            Debug.LogError("No target for moon");
            Destroy(gameObject);
        }
        GetComponent<Mover>().SetTarget(target);
        ground = GameObject.Find("Ground").GetComponent<Ground>();
        health = maxHealth;
    }

    private void Update() 
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < gravityDisruptDistance) {
            Physics.gravity = new Vector3(0f, 5f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bumper") || other.name.Equals("Ground")) {
            ground.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        float healthRatio = 1 - ((float) health / (float) maxHealth);
        healthOMeter.ApplyDamage(healthRatio);
        if (health <= 0) {
            Debug.LogWarning("You WON, the Moon is dead");
        }
    }
}
