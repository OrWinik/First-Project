using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int enemylife = 3;
    public float EnemySpeed = 2;
    public GameObject spawner;
    public SpriteRenderer EnemyRb;
    Vector3 movement = Vector3.left;
    public int amoutofenemies;
    

    // Update is called once per frame
    void Update()
    {
        transform.position += movement * (EnemySpeed * Time.deltaTime);
       
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Walls"))
        {
            if (EnemyRb.flipX == true)
            {
                EnemyRb.flipX = false;
                movement = Vector3.left;
            }
            else
            {
                EnemyRb.flipX = true;
                movement = Vector3.right;
            }
        }
    }

    public void CheckScore()
    {
        enemylife--;
        if (enemylife <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}