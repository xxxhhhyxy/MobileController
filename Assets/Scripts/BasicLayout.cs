using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BasicLayout : MonoBehaviour
{
    public Button btn_back;
        // Start is called before the first frame update
    protected virtual void Start()
    {
        btn_back.onClick.AddListener(f_btn_Back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void f_btn_Back()
    {
        SceneManager.LoadScene("StartScene");
    }
}
