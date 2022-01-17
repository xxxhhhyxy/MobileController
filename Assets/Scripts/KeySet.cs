using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class KeySet : MonoBehaviour
{
    public UnityEvent<dir> DirClickEvent;
    public UnityEvent<dir> DirDownEvent;
    public UnityEvent<dir> DirUpEvent;
    public enum dir
    {
        up,
        down,
        left,
        right,
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void keyClick(dir input)
    {
        DirClickEvent.Invoke(input);
    }
    public void keyDown(dir input)
    {
        DirDownEvent.Invoke(input);
    }
    public void keyUp(dir input)
    {
        DirUpEvent.Invoke(input);
    }

}
