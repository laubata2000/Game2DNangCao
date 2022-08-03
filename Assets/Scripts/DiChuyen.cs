using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DiChuyen : MonoBehaviour
{
    //public GameObject imgNen;
    //public GameObject imgChu;
    //public GameObject textGameOver;
    //public GameObject btnSetting;
    //public GameObject btnReplay;
    public float speed = 1f;
    public Animator ani;
    public bool isRight = true;
    public bool Pause = false;
    private new Rigidbody2D rigidbody;
    public AudioSource soundjump;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
            //rigidbody.velocity = new Vector2(speed*(-1), rigidbody.velocity.y);
            transform.Translate(-Time.deltaTime*5, 0, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            ani.SetBool("isRuning", true);
            ani.Play("Running");
            
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            //rigidbody.velocity = new Vector2(speed * (1), rigidbody.velocity.y);
            transform.Translate(Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            ani.SetBool("isRuning", true);
            ani.Play("Running");
        }else if (Input.GetKey(KeyCode.Space))
        {
            if(isRight == true)
            {
                transform.Translate(Time.deltaTime*5, Time.deltaTime * 15, 0);
                soundjump.Play();
                ani.Play("nhay");

            }
            else
            {
                transform.Translate(-Time.deltaTime*3, Time.deltaTime * 10, 0);
                soundjump.Play();
                ani.Play("nhay");
            }

        }
        else
        {
            ani.SetBool("isRuning", false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hancuoi")
        {
            //imgNen.SetActive(true);
            //imgChu.SetActive(true);
            //textGameOver.SetActive(true);
            //btnSetting.SetActive(true);
            //btnReplay.SetActive(true);
            SceneManager.LoadScene("man0");
            

        }
    }


    





}
