using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenChange : MonoBehaviour
{
    public bool isPunch = false;                        //���������� �Է��� �����°��� �������� Flag ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        //��ġ üũ�� false�� ���
        {
            if (!isPunch)
            {
                isPunch = true;                         //��ġ üũ�� True�� ������༭ ��� �Է��� ������ ������ �������� ���ϰ� ���´�.
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPunch);    //��Īȿ���� ���� ������ EndPunch�Լ��� ȣ��
            }
        }
        
    }

    void EndPunch()
    {
        isPunch = false;
    }
}