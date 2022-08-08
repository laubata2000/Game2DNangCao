using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dichuyen1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public Animator ani;
    public bool isRight = true;
    public bool Pause = false;
    private new Rigidbody2D rigidbody;
    public AudioSource soundjump;
    void Start()
    {
        ani = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        soundjump.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
            //rigidbody.velocity = new Vector2(speed*(-1), rigidbody.velocity.y);
            transform.Translate(-Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);
            ani.SetBool("Chaynha", true);
            ani.Play("Player2");

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            //rigidbody.velocity = new Vector2(speed * (1), rigidbody.velocity.y);
            transform.Translate(Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            ani.SetBool("Chaynha", true);
            ani.Play("Player2");
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (isRight == true)
            {
                transform.Translate(Time.deltaTime * 5, Time.deltaTime * 15, 0);
                soundjump.Play();
                ani.Play("NhayPlayer2");

            }
            else
            {
                transform.Translate(-Time.deltaTime * 3, Time.deltaTime * 10, 0);
                soundjump.Play();
                ani.Play("NhayPlayer2");
            }

        }
        else
        {
            ani.SetBool("Chaynha", false);
        }

    }
}
