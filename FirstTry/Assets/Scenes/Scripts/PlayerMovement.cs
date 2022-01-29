using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public int HP = 3;
    public float speed = 3;
    public Transform target;
    public SpriteRenderer Player;
    public float jumpforce = 3;
    public Rigidbody2D player;
    public float cooldown = 3;
    bool active;
    float LastJump = 3;
    public GameObject[] Hearts;
    



    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (HP < 1)
        {
            Destroy(Hearts[0].gameObject);
        }
        else if (HP < 2)
        {
            Destroy(Hearts[1].gameObject);
        }
        else if (HP < 3)
        {
            Destroy(Hearts[2].gameObject);
        }
        
        float Horizontal = Input.GetAxisRaw("Horizontal");      
        target.position += Vector3.right * (speed * Time.deltaTime * Horizontal);
        if (Horizontal >= 0)
        {
            Player.flipX = false;
        }
        else
            Player.flipX = true;

        LastJump = LastJump + Time.deltaTime;
        if (cooldown < LastJump)
        {
            active = true;
        }
        else
        {
            active = false;
            LastJump = LastJump + Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space) && active == true)
        {
            player.AddForce(Vector3.up * jumpforce);
            LastJump = 0;

        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.CompareTag("HeadCollider"))
        {
            other.gameObject.GetComponent<Enemy>().CheckScore();
            Debug.Log("HeadCollider");
        }
        
        if (other.collider.CompareTag("enemy"))
        {
             HP--;
            Debug.Log("enemy " + HP);
        }

        
       
    }


     
}
