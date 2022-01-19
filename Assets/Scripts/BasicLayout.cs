using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BasicLayout : MonoBehaviour
{
    public Button btn_back;
    public Toggle tg_turn;
    public TMP_Text txt;
    public Scrollbar scr;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        btn_back.onClick.AddListener(f_btn_Back);
        tg_turn.onValueChanged.AddListener(changeScrPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void f_btn_Back()
    {
        SceneManager.LoadScene("StartScene");
    }
    private void changeScrPos(bool input)
    {
        txt.text = input ? "Right" : "Left";
        scr.transform.localPosition = new Vector3(-scr.transform.localPosition.x, scr.transform.localPosition.y, scr.transform.localPosition.z);
    }
}
