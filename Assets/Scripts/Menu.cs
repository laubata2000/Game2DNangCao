using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;



public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField txtUSN;
    public InputField txtPW;

    public static string LOGIN_URL = "https://sale.daiduongcorp.vn/servergameapi/views/checklogin.php";

    private IEnumerator CreatRequest() {
        string user_name = txtUSN.GetComponent<InputField>().text;
        string password = txtPW.GetComponent<InputField>().text;
        if (string.Equals(user_name.Trim(), "") || string.Equals(password.Trim(), ""))
        {
            Debug.Log("tai khoan hoac mat khau sai");
        }
        else
        {
            WWWForm form = new WWWForm();
            form.AddField("username", user_name);
            form.AddField("password", password);
            UnityWebRequest request = UnityWebRequest.Post(LOGIN_URL, form);
            yield return request.SendWebRequest();
            if (request.responseCode == 200)
            {

                SceneManager.LoadScene("man0");
            }
            else
            {
                Debug.Log("tai khoan hoac mat khau sai");
            }
        }

        
      
    }
    public void Login()
    {
        StartCoroutine(CreatRequest());
    }
}

