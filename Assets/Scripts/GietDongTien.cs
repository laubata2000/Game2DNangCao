using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GietDongTien : MonoBehaviour
{
    // Start is called before the first frame update
    public static int diemTong = 0;
    public GameObject diemText;
    public GameObject imgNen;
    public GameObject textSavePoint;

    public AudioSource soundmain;
    public AudioSource soundchet;
    public AudioSource soundcoin;
    void Start()
    {
        soundmain.Play();
        soundchet.Stop();
        soundcoin.Stop();
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
        textSavePoint.GetComponent<Text>().text = "Điểm của bạn: " + diemTong.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //string name_monster = collision.attachedRigidbody.gameObject.name;
        string dongtien = collision.attachedRigidbody.gameObject.name;
        //string lua = collision.attachedRigidbody.gameObject.name;
        //if (collision.gameObject.tag == "ben_trai")
        //{
        //    soundmain.Stop();



        //    Destroy(GameObject.Find("Lep"));
        //    soundchet.Play();
        //    imgNen.SetActive(true);
        //    imgChu.SetActive(true);
        //    textGameOver.SetActive(true);
        //    btnSetting.SetActive(true);
        //    btnReplay.SetActive(true);
        //    //SceneManager.LoadScene("man0");



        //}

        //if (collision.gameObject.tag == "ben_tren")
        //{

        //    Destroy(GameObject.Find(name_monster));
        //    CongDiem(1);
        //    giet.Play();
        //}

        if (collision.gameObject.tag == "bentrenlua")
        {

            Destroy(GameObject.Find("Lep_Kid-hd_0"));
            soundmain.Stop();
            soundchet.Play();
            imgNen.SetActive(true);
            //CongDiem(1);
            //giet.Play();
        }



        if (collision.gameObject.tag == "coin_nhe")
        {

            Destroy(GameObject.Find(dongtien));
            soundcoin.Play();
            CongDiem(1);
            //Instantiate(PScoin, collision.gameObject.transform.position, collision.gameObject.transform.localRotation);
            //soundcoin.Play();
        }

        if (collision.gameObject.tag == "handuoi")
        {

            Destroy(GameObject.Find("Lep_Kid-hd_0"));
            soundmain.Stop();
            soundchet.Play();
            imgNen.SetActive(true);
            //Instantiate(PScoin, collision.gameObject.transform.position, collision.gameObject.transform.localRotation);
            //soundcoin.Play();
        }






    }
    
}
