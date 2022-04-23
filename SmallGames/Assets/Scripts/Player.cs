using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Score score;
    public string currentColor;
    public Color cyan, yellow, red, purple;
    LevelSpawner levelSpawner;
    bool isMoving = false;
    public GameObject deathParticules, starParticules;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        score = FindObjectOfType<Score>();
        levelSpawner = FindObjectOfType<LevelSpawner>();
        SetRandomColor();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Input.GetButton("Jump"))
        {
            Move();
        }

        if(Input.touchCount > 0)
        {
            Move();
        }
    }

    private void Move()
    {
        if(!isMoving)
        {
            isMoving = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            AudioManager.instance.Play("Start");
            rb.velocity = Vector2.up * jumpForce;
            return;
        }
        rb.velocity = Vector2.up * jumpForce;
        AudioManager.instance.Play("Jump");
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
            Instantiate(starParticules, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            score.IncreaseScore();
            AudioManager.instance.Play("Star");
            return;
        }

        if(collision.tag != currentColor)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        AudioManager.instance.Play("BallBreak");
        sr.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        Instantiate(deathParticules, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
