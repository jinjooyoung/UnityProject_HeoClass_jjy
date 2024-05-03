using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExPlayer : MonoBehaviour
{
    public Rigidbody m_RigidBody;         //������ٵ� �ҽ��� ����ϰ� �޾� �´�.
    public int Force = 100;             //int ������ ���� 100���� �����Ѵ�.
    public int point = 0;               //���� ����� ���� �߰�
    public float checkTime = 0;         //�ð� ������ ���� ���� (�Ҽ���)
    public Text m_Text;                 //UI�ؽ�Ʈ ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //���콺 �Է��� ������ ��
        {
            m_RigidBody.AddForce(transform.up * Force);       //transform.up(���� ����)���� ������ �ٵ� Force ����ŭ ������ ���� �ش�.
        }

        checkTime += Time.deltaTime;                //������ ������ ���ؼ� �ð��� ����
        if(checkTime >= 1.0f)                       //���� 1�ʰ� ������ ���
        {
            point += 1;                             //1���� �����ش�
            checkTime = 0.0f;                       //1�ʰ� ������� �ʱ�ȭ
        }

        m_Text.text = point.ToString();             //UIǥ��
    }

    private void OnCollisionEnter(Collision collision)      //�浹�� ���� �Ǿ��� ��
    {
        if(collision != null)                               //�浹 ��ü�� ������ ���
        {
            point = 0;                                  //�浹�� �Ͼ�� �� ����Ʈ�� 0���� �����.
            gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f);      //�浹�Ͽ��� �� ��ġ �ʱ�ȭ
            Debug.Log(collision.gameObject.tag);       //�ش� ������Ʈ�� �̸��� ����Ѵ�

        }
    }

    //�ݶ��̴� ������Ʈ�� is trigger �� üũ�ϸ� �浹 ����ȿ���� ���������� �������� Ȯ�� �� �� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))       //CompareTag �Լ��������� Tag(Item) �̸��� �˻��Ѵ�.
        {
            Debug.Log("�����۰� �⵿��.");
            point += 10;                    //10�� ����Ʈ�� �ø���. point = point + 10�� ����ǥ��
            Destroy(other.gameObject);      //�ı��Ѵ�.
        }
    }
}