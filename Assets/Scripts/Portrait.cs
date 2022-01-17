using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Portrait : BasicLayout
{ 
    public Toggle tg_turn;
    public TMP_Text txt;
    public Scrollbar scr;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Screen.autorotateToPortrait = true;
        tg_turn.onValueChanged.AddListener(changeScrPos);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void changeScrPos(bool input)
    {
        txt.text = input ? "Right" : "Left";
        scr.transform.localPosition = new Vector3(-scr.transform.localPosition.x, scr.transform.localPosition.y, scr.transform.localPosition.z);
    }

}