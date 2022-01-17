using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PadHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image m_back;
    public Image m_image;
    private Vector2 sizeBack;
    private Vector2 sizeImage;
    private float limit;
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Vector3.Distance(eventData.position, m_back.transform.position) > limit)
            transform.position = ((Vector3)eventData.position - m_back.transform.position).normalized * limit + m_back.transform.position;
        else
            transform.position = eventData.position;
        //Debug.Log(transform.localPosition.x+"/"+transform.localPosition.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        sizeBack = m_back.rectTransform.sizeDelta;
        sizeImage = m_image.rectTransform.sizeDelta;
        limit = sizeBack.x / 2 - sizeImage.x / 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}