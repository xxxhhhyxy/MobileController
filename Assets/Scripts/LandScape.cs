using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScape : BasicLayout
{
    // Start is called before the first frame update

    protected override void Start()
    {
        base.Start();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
