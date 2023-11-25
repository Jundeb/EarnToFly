using System.Collections;
using UnityEngine;

public class CannonBall : Enemy

{
    private GameObject plane;
    private PlayerHealth playerHealth;

    public override void TakeDamage(float amount)
    {
        //Destroy(gameObject);
    }

    public override void Die()
    {
        // play death animation

    }

    public override void DropLoot()
    {

    }

    public override void InflictContactDamage(float amount)
    {
        playerHealth.TakeDamage(amount);
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InflictContactDamage(contactDamage);
            TakeDamage(0);
        }
    }

    public override void SetColor(Color color)
    {

    }

    public override void Attack()
    {

    }

    private void Awake()
    {
        plane = GameObject.FindGameObjectWithTag("Player");
        playerHealth = plane.GetComponent<PlayerHealth>();
    }
}