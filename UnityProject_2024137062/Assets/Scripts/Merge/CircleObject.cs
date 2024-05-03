using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;         // �巡�� ������ �Ǵ��ϴ� ��
    public bool isUsed;         // ��� �Ϸ� �Ǵ��ϴ� ��
    Rigidbody2D rigidbody2D;    // 2D ��ü�� �ҷ��´�

    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;                             // ��� �Ϸᰡ ���� ���� (ó�� ���)
        rigidbody2D = GetComponent<Rigidbody2D>();  // ��ü�� �����´�.
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed) return;                             // ��� �Ϸ�� ��ü�� ���̻� ������Ʈ ���� �ʱ� ���ؼ� return���� �����ش�. (������ ������ ���� �ڵ带 ���� ����)

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     // ȭ�鿡�� ���� ������ ��ġ ã���ִ� �Լ�
            float leftBorder = -4.0f + transform.localScale.x / 2f;                     // �ִ� �������� �� �� �ִ� ����
            float rightBorder = 4.0f - transform.localScale.x / 2f;                     // �ִ� ���������� �� �� �ִ� ����

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;    // �ִ� �������� �� �� �ִ� ������ �Ѿ ��� �ִ� ���� ��ġ�� �����ؼ� �Ѿ�� ���ϰ� �Ѵ�.
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;  // �ִ� ���������� �� �� �ִ� ������ �Ѿ ��� �ִ� ���� ��ġ�� �����ؼ� �Ѿ�� ���ϰ� �Ѵ�.

            mousePos.y = 8;
            mousePos.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);  // �� ������Ʈ�� ��ġ�� ���콺 ��ġ�� �̵� �ȴ�. (0.2f�� �ӵ���)
        }

        if (Input.GetMouseButtonDown(0)) Drag();        // ���콺 ��ư�� ������ �� Drag �Լ� ȣ��
        if (Input.GetMouseButtonUp(0)) Drop();          // ���콺 ��ư�� �ö� �� Drop �Լ� ȣ��
    }

    void Drag()
    {
        isDrag = true;                  // �巡�� ���� true
        rigidbody2D.simulated = false;  // �巡�� �߿��� ���� ������ �Ͼ�� �� �ǹǷ� �װ��� ���� ���� false
    }

    void Drop()
    {
        isDrag = false;                 // �巡�װ� ����
        isUsed = true;                  // ����� �Ϸ�
        rigidbody2D.simulated = true;   // ���� ���� ����

        GameObject Temp = GameObject.FindWithTag("GameManager");            // �±װ� ���� �Ŵ����� ���� ã�Ƽ� ������Ʈ�� �����´�.
        if (Temp != null)                                                   // �ش� ������Ʈ�� �����ϸ� (=ã�� �Ϳ� �����ߴٸ�)
        {
            Temp.gameObject.GetComponent<GameManager>().GenObject();        // GenObject() �Լ��� ȣ���Ѵ�.
        }
    }
}