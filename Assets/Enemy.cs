using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public Color color;
    public float spawnLocation;
    public float movementSpeed;
    public float contactDamage;
    public int loot;

    public void Attack() {

    }
    public abstract void DropLoot();
    public abstract void Die();
    public abstract void InflictContactDamage(float amount);
    public abstract void TakeDamage(float amount);
    public abstract void SetColor(Color color);

}
