using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public string currentColor;
    public Color cyan, yellow, red, purple;
    public LevelSpawner levelSpawner;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Input.GetButton("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = cyan;
                break;

            case 1:
                currentColor = "Yellow";
                sr.color = yellow;
                break;

            case 2:
                currentColor = "Red";
                sr.color = red;
                break;

            case 3:
                currentColor = "Purple";
                sr.color = purple;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ColorChanger")
        {
            SetRandomColor();
            levelSpawner.SpawnLevel();
            Destroy(collision.gameObject);
            return;
        }

        if(collision.tag != currentColor)
        {
            Debug.Log("You Died.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
