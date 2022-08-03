using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gietquai : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource soundmain;
    public AudioSource soundchet;
    public AudioSource soundcoin;
    public AudioSource giet;


    public GameObject imgNen;
    public GameObject imgChu;
    public GameObject textGameOver;
    public GameObject btnSetting;
    public GameObject btnReplay;
    public static int diemTong = 0;
    public GameObject diemText;
    public GameObject PScoin;




    void Start()
    {
        CongDiem(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CongDiem(int diemCong)
    {
        diemTong += diemCong;
        diemText.GetComponent<Text>().text = "Coin: " + diemTong.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name_monster = collision.attachedRigidbody.gameObject.name;
        string dongtien = collision.attachedRigidbody.gameObject.name;
        string conchim = collision.attachedRigidbody.gameObject.name;
        if (collision.gameObject.tag == "ben_trai")
        {
            soundmain.Stop();
            
            
            
            Destroy(GameObject.Find("Lep"));
            soundchet.Play();
            imgNen.SetActive(true);
            imgChu.SetActive(true);
            textGameOver.SetActive(true);
            btnSetting.SetActive(true);
            btnReplay.SetActive(true);
            //SceneManager.LoadScene("man0");



        }
        
        if (collision.gameObject.tag == "ben_tren")
        {
            
            Destroy(GameObject.Find(name_monster));
            CongDiem(1);
            giet.Play();
        }

        if (collision.gameObject.tag == "phiaduoi")
        {

            Destroy(GameObject.Find(conchim));
            CongDiem(1);
            giet.Play();
        }

        if (collision.gameObject.tag == "coinne")
        {

            Destroy(GameObject.Find(dongtien));
            CongDiem(1);
            Instantiate(PScoin, collision.gameObject.transform.position, collision.gameObject.transform.localRotation);
            soundcoin.Play();
        }

        

    }

    
}
