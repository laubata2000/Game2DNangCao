using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quainho : MonoBehaviour
{
    bool gioi_han;
    bool gioi_han1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gioi_han)
        {
            transform.Translate(Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.Translate(-Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (gioi_han1)
        {
            transform.Translate(-Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "gioi_han")
        {
            gioi_han = true;

        }
        else if (collision.gameObject.tag == "gioi_han1")
        {
            gioi_han1 = true;
            gioi_han = false;
        }
        else
        {
            gioi_han1 = false;
        }








    }
}
