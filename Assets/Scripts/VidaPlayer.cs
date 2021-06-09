using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject gameOverText;
    public GameObject restartButton;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (currentHealth == 0)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    //Profe no se porque razon me detecta la colision pero no me saca vida, pero apretando el espacio por ejemplo si me saca la vida, por esa razon dejo ambos codigos a ver si me puede dar una solucion

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Bullet")
        {
            TakeDamage(20);
        }

        Debug.Log(collisionInfo.collider.name);

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
