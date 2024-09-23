using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePattern : MonoBehaviour
{
    /*
    <��������>
    - ��ü���� �� ���� �ϳ��� ���¸��� ������ �Ѵ�
    - ��ü�� ���� ���¿� �ش��ϴ� �ൿ���� ������
    - ��ü�� �ٸ� �ൿ�� �ʿ��� ��� ���� ���¸� ��ȯ���ֵ��� ��

    <����>
    1. ������ �ڷ������� ��ü�� ���� �� �ִ� ���µ��� ����
    2. ���� ���¸� �����ϴ� ������ �ʱ� ���¸� ����
    3. ��ü�� �ൿ�� �־ ���� ���¸��� �ൿ�� ����
    4. ��ü�� ���� ������ �ൿ�� ������ �� ���� ��ȭ�� ���� �Ǵ�
    5. ���� ��ȭ�� �־�� �ϴ� ��� ���� ���¸� ��� ���·� ����
    6. ���°� ����� ��� ���� �ൿ�� �־ �ٲ� ���¸��� �ൿ�� ����

    <����>
    - ���ǹ��� ���·� ó���� �����ϹǷ�, ������ ���� ó���� ���� �δ��� ����
    - ���� ���¿� ���� ���길 ó���ϹǷ�, ���� �ӵ��� �پ
    - ������ ������ ������ ���¸� �л��Ű�Ƿ�, �ڵ尡 �����ϰ� �������� ����

    <������>
    - ������ ������ ��Ȯ���� �ʰų� ������ ���� ���, ���� �ڵ尡 �������� �� ����

     */


    /*if (isDead == false)
    {
        if (Vector2.Distance(transform.position, player.transform.position) < traceRange)
        {
            //�����ϱ�
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            //�����ϱ�
            if (Vector2.Distance(transform.position, player.transform.position) < attackRange)
            {
                Debug.Log("�����Ѵ�");
            }
        }
        else
        {
            //���ư���
            if (Vector2.Distance(transform.position, startPos) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            }

            //���
            else
            {
                //�ƹ��͵� �� ��
            }
        }
    }

    //�׾�����
    else
    {

    }*/

    /* private void Update()
        {

            switch (curState)
            {
                case State.Idle:
                    Idle();
                    break;
                case State.Trace:
                    Trace();
                    break;
                case State.Return:
                    Return();
                    break;
                case State.Attack:
                    Attack();
                    break;
                case State.Dead:
                    Dead();
                    break;
            }
        }

        //���� �ൿ���� �ڽ��� �ൿ�� �� �ٸ� �ൿ X
        private void Idle()
        {
            //������ �ֱ�

            //�ٸ� ���·� ��ȯ
            if (Vector2.Distance(transform.position, player.transform.position) < traceRange)
            {
                curState = State.Trace;
            }
        }

        private void Trace()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            //�ٸ� ���·� ��ȯ
            if (Vector2.Distance(transform.position, player.transform.position) > traceRange)
            {
                curState = State.Return;
            }

            else if (Vector2.Distance(transform.position, player.transform.position) < attackRange)
            {
                curState = State.Attack;
            }
        }

        private void Return()
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, startPos) < 0.01f)
            {
                curState = State.Idle;
            }
        }

        private void Attack()
        {
            Debug.Log("����");

            if (Vector2.Distance(transform.position, player.transform.position) > traceRange)
            {
                curState = State.Trace;
            }
        }

        private void Dead()
        {
            Debug.Log("����");
        }*/

}
