using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollowObject : MonoBehaviour
{
    public Transform targetObject;              // ����ٴ� 3D ������Ʈ
    public Vector3 offset;                      // ��ġ�� ����
    public Slider slider;                       // ����ٴ� SliderUI

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null && slider != null)
        {
            // 3D ������Ʈ�� ��ġ�� ȭ�� ��ǥ�� ��ȯ��
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObject.position + offset);

            // ȭ�� ��ǥ�� Canvas ��ǥ�� ��ȯ
            RectTransform canvasRect = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out canvasPos);

            // Slider UI ��ġ�� ������Ʈ
            slider.transform.localPosition = canvasPos;
        }
    }
}