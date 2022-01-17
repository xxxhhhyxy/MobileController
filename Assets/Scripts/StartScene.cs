using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class StartScene : MonoBehaviour
{
    public enum Layout
    {
        Portrait=0,
        PlayStation=1,
        XBox=2,
        Switch=3,
    }
    public TMP_Dropdown dp_Layout;
    public Toggle tg_UDPOrTCP;
    public Toggle tg_ClientOrServer;
    public TMP_InputField input_IP;
    public TMP_InputField input_Port;
    // Start is called before the first frame update
    void Start()
    {
        dp_Layout.options.Clear();        
        for(int i=0;i<Enum.GetValues(typeof(Layout)).Length ;i++ )
        {
            dp_Layout.options.Add(new TMP_Dropdown.OptionData(((Layout)i).ToString()));
        }
        tg_UDPOrTCP.onValueChanged.AddListener(f_tg_UDPOrTCP);
        tg_ClientOrServer.onValueChanged.AddListener(f_tg_ClientOrServer);
        Screen.autorotateToPortrait = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void f_tg_UDPOrTCP(bool input)
    {
        tg_UDPOrTCP.GetComponentInChildren<TMP_Text>().text = input ? "UDP" : "TCP";
    }
    private void f_tg_ClientOrServer(bool input)
    {
        tg_ClientOrServer.GetComponentInChildren<TMP_Text>().text = input ? "Client" : "Server";
    }
    public void f_btn_Connect()
    {

    }
    public void f_btn_Start()
    {
        switch ((Layout)dp_Layout.value)
        {
            case Layout.Portrait:
                SceneManager.LoadScene("Portrait");
                break;
            case Layout.PlayStation:
                SceneManager.LoadScene("PlayStation");
                break;
            case Layout.XBox:
                SceneManager.LoadScene("Xbox");
                break;
            case Layout.Switch:
                SceneManager.LoadScene("Switch");
                break;
            default:
                break;
        }
    }
}
