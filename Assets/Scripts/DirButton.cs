using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DirButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerClickHandler
{
    public KeySet.dir m_dir;
    public KeySet m_DirectionSet;
    public void OnPointerClick(PointerEventData eventData)
    {
        m_DirectionSet.keyClick(m_dir);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_DirectionSet.keyDown(m_dir);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_DirectionSet.keyUp(m_dir);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
