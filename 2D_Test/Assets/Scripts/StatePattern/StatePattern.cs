using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePattern : MonoBehaviour
{
    /*
    <상태패턴>
    - 객체에게 한 번에 하나의 상태만을 가지게 한다
    - 객체는 현재 상태에 해당하는 행동만을 진행함
    - 객체가 다른 행동이 필요한 경우 현재 상태를 전환해주도록 함

    <구현>
    1. 열거형 자료형으로 객체가 가질 수 있는 상태들을 정의
    2. 현재 상태를 저장하는 변수에 초기 상태를 지정
    3. 객체는 행동에 있어서 현재 상태만의 행동을 진행
    4. 객체는 현재 상태의 행동을 진행한 후 상태 변화에 대해 판단
    5. 상태 변화가 있어야 하는 경우 현재 상태를 대상 상태로 지정
    6. 상태가 변경된 경우 다음 행동에 있어서 바뀐 상태만의 행동을 진행

    <장점>
    - 조건문을 상태로 처리가 가능하므로, 복잡한 조건 처리에 대한 부담이 적음
    - 현재 상태에 대한 연산만 처리하므로, 연산 속도가 뛰어남
    - 동작의 구현을 각각의 상태를 분산시키므로, 코드가 간결하고 가독성이 좋음

    <주의점>
    - 상태의 구분이 명확하지 않거나 갯수가 많은 경우, 상태 코드가 복잡해질 수 있음

     */


    /*if (isDead == false)
    {
        if (Vector2.Distance(transform.position, player.transform.position) < traceRange)
        {
            //추적하기
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            //공격하기
            if (Vector2.Distance(transform.position, player.transform.position) < attackRange)
            {
                Debug.Log("공격한다");
            }
        }
        else
        {
            //돌아가기
            if (Vector2.Distance(transform.position, startPos) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            }

            //대기
            else
            {
                //아무것도 안 함
            }
        }
    }

    //죽었으면
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

        //각자 행동에서 자신의 행동만 함 다른 행동 X
        private void Idle()
        {
            //가만히 있기

            //다른 상태로 전환
            if (Vector2.Distance(transform.position, player.transform.position) < traceRange)
            {
                curState = State.Trace;
            }
        }

        private void Trace()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            //다른 상태로 전환
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
            Debug.Log("공격");

            if (Vector2.Distance(transform.position, player.transform.position) > traceRange)
            {
                curState = State.Trace;
            }
        }

        private void Dead()
        {
            Debug.Log("죽음");
        }*/

}
