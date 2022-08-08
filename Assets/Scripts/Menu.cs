using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using Newtonsoft.Json;




public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputField inputFUser;
    [SerializeField] private InputField inputFPassword;
    [SerializeField] private InputField inputFUserRegister;
    [SerializeField] private InputField inputFPasswordRegister;
    [SerializeField] private InputField inputConfirmPassword;
    [SerializeField] private Text txtNotification;
    [SerializeField] private Text txtNotificationRegister;
    //[SerializeField] private Slider sliderVolume;
    //[SerializeField] private AudioSource audio;

    public List<UserInfo> list;
    private string path;


    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/user.txt";
        //sliderVolume.value = audio.volume
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetLogin()
    {
        if (inputFUser.text == "admin" && inputFPassword.text == "123")
        {

            //PlayerPrefs.SetFloat("volumeMusic", audio.volume);
            SceneManager.LoadScene("man0");
        }
        else
        {
            txtNotification.gameObject.SetActive(true);
            txtNotification.text = "Failed Login.Try again!";
        }
        string username = inputFUser.text;
        string password = inputFPassword.text;
        if (!File.Exists(path))
            return;
        list = LocalDb(null);
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].username.Equals(username))
            {
                if (list[i].password.Equals(password))
                {
                    //login sucessfully!
                    txtNotification.gameObject.SetActive(false);
                    //PlayerPrefs.SetFloat("volumeMusic", audio.volume);
                    PlayerPrefs.SetString("username", list[i].username);
                    SceneManager.LoadScene("man0");
                    return;
                }
                else
                {
                    //login failed!(Wrong password)
                    txtNotification.gameObject.SetActive(true);
                    txtNotification.text = "Sai mật khẩu.Vui lòng thử lại!";
                    return;
                }
            }
        }
        txtNotification.gameObject.SetActive(true);
        txtNotification.text = "Tài khoản không tồn tại";

    }
    public void SetRegister()
    {
        string username = inputFUserRegister.text;
        string password = inputFPasswordRegister.text;
        string confirmPw = inputConfirmPassword.text;
        if (!password.Equals(confirmPw))
        {
            //Mat khau khong chinh xac
            txtNotificationRegister.gameObject.SetActive(true);
            txtNotificationRegister.text = "Mật khẩu không trùng khớp";
            return;
        }
        //check username da ton tai chua?
        var userInfo = new UserInfo
        {
            username = username,
            password = password,
            sound = 0f,
            point = 0
        };

        List<UserInfo> listUser = LocalDb(userInfo);
        if (listUser.Count == 0)
        {
            txtNotificationRegister.gameObject.SetActive(true);
            txtNotificationRegister.text = "Đăng ký thành công";
            //luu thanh cong
            return;
        }
        if (listUser.Find(user => user.username == userInfo.username) != null)
        {
            //tai khoan da ton tai
            txtNotificationRegister.gameObject.SetActive(true);
            txtNotificationRegister.text = "Tài khoản đã tồn tại";
            return;
        }
        listUser.Add(userInfo);
        StreamWriter stream = new StreamWriter(path);
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(stream, listUser);
        stream.Close();
        txtNotificationRegister.gameObject.SetActive(true);
        txtNotificationRegister.text = "Đăng ký thành công";
    }
    private List<UserInfo> LocalDb(UserInfo user)
    {
        list = new List<UserInfo>();
        if (!File.Exists(path))
        {
            list.Add(user);
            StreamWriter stream = new StreamWriter(path);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(stream, list);
            stream.Close();
            list.Remove(user);
            return list;
        }
        StreamReader streamReader = new StreamReader(path);
        string data = streamReader.ReadToEnd();
        streamReader.Close();
        list = JsonConvert.DeserializeObject<List<UserInfo>>(data);

        return list;
    }
    //public void SetVolume()
    //{
    //    audio.volume = sliderVolume.value;
    //}


}
public class UserInfo
{
    public string username;
    public string password;
    public float sound;
    public int point;

}

    


