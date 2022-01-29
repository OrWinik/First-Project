using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpwanerLvl3 : MonoBehaviour
{
    int spwanAmout = 3;
    public GameObject Enemy;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spwanAmout; i++)
        {
          
            Spawn();

        }
    }
    public void Update()
    {

        if (GameObject.Find("Enemy1(Clone)") == null)
        {
            checkLvl();

        }
    }

    public void checkLvl()
    {
        FindObjectOfType<PauseMenu>().PauseMenuUI.SetActive(true);
        
    }


    private void Spawn()
    {


        Instantiate(Enemy, new Vector3(Random.Range(4, -4), -2, 0), Enemy.transform.rotation);



    }

}
