using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [Header("Starting states")]

    public float speed;
    Vector2 input;
    Rigidbody2D playerRigidbody;

    [Header("Shooting")]
    public GameObject bullet;
    public GameObject[] bulletSpawnPositions;
    private float cools;
    public float timeBetweenShots;

    [Header("Health")]
    public int maxHealth = 10;
    public int health;

    public GameObject HealthImage;
    public GameObject healthParent;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        cools = timeBetweenShots;
        health = maxHealth;
        for (int i = 0; i < health - 1; i++)
            AddHear();
        
    }
    void AddHear()
    {
        GameObject heart = Instantiate(HealthImage);
        heart.transform.SetParent(healthParent.transform);
    }

    void RemoveHeart(int n)
    {
        if (healthParent.transform.childCount > 0)
        {
            if (healthParent.transform.childCount < 0)
                n = healthParent.transform.childCount;
            for (int i = 0; i < n; i++)
                Destroy(healthParent.transform.GetChild(0).gameObject);

        }
    }
    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRigidbody.AddForce(input * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && cools <= 0)
            Shoot();
        if (cools > 0) cools -= Time.deltaTime;

    }

    void Shoot()
    {

        for (int i = 0; i < bulletSpawnPositions.Length; i++)
            Instantiate(bullet, bulletSpawnPositions[i].transform.position, Quaternion.identity);
        cools = timeBetweenShots;

    }
    public void TakeDamage(int dmg)
    {
        RemoveHeart(dmg);
        health -= dmg;
        if (health <= 0)
            GameOver();
    }
    void GameOver()
    {

    }
}
