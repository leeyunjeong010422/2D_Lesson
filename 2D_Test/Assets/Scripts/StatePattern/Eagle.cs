using UnityEngine;
using UnityEngine.UI;

public class Eagle : MonoBehaviour
{
    public enum State { Idle, Trace, Return, Attack, Dead, Size }
    [SerializeField] State curState = State.Idle;
    private BaseState[] states = new BaseState[(int)State.Size];

    [SerializeField] GameObject player;
    [SerializeField] float traceRange;
    [SerializeField] float attackRange;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 startPos;

    //[SerializeField] Text stateText;

    private void Awake()
    {
        states[(int)State.Idle] = new IdleState(this);
        states[(int)State.Trace] = new TraceState(this);
        states[(int)State.Return] = new ReturnState(this);
        states[(int)State.Attack] = new AttackState(this);
        states[(int)State.Dead] = new DeadState(this);
    }

    private void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        states[(int)curState].Enter();
    }

    private void OnDestroy()
    {
        states[(int)curState].Exit();
    }

    private void Update()
    {
        states[(int)curState].Update();

        //stateText.text = curState.ToString();
    }

    public void ChangeState(State nextState)
    {
        states[(int)curState].Exit();
        curState = nextState;
        states[(int)curState].Enter();
    }

    private class EagleState : BaseState
    {
        public Eagle eagle;

        public EagleState(Eagle eagle)
        {
            this.eagle = eagle;
        }
    }

    private class IdleState : EagleState
    {
        public IdleState(Eagle eagle) : base(eagle)
        {
        }

        public override void Update()
        {
            // Idle �ൿ�� ����
            // ������ �ֱ�

            // �ٸ� ���·� ��ȯ
            if (Vector2.Distance(eagle.transform.position, eagle.player.transform.position) < eagle.traceRange)
            {
                eagle.ChangeState(State.Trace);
            }
        }
    }

    private class TraceState : EagleState
    {
        public TraceState(Eagle eagle) : base(eagle)
        {
        }

        public override void Update()
        {
            // Trace �ൿ�� ����
            eagle.transform.position = Vector2.MoveTowards(eagle.transform.position, eagle.player.transform.position, eagle.moveSpeed * Time.deltaTime);

            // �ٸ� ���·� ��ȯ
            if (Vector2.Distance(eagle.transform.position, eagle.player.transform.position) > eagle.traceRange)
            {
                eagle.ChangeState(State.Return);
            }
            else if (Vector2.Distance(eagle.transform.position, eagle.player.transform.position) < eagle.attackRange)
            {
                eagle.ChangeState(State.Attack);
            }
        }
    }

    private class ReturnState : EagleState
    {
        public ReturnState(Eagle eagle) : base(eagle)
        {
        }

        public override void Update()
        {
            // Return �ൿ�� ����
            eagle.transform.position = Vector2.MoveTowards(eagle.transform.position, eagle.startPos, eagle.moveSpeed * Time.deltaTime);

            if (Vector2.Distance(eagle.transform.position, eagle.startPos) < 0.01f)
            {
                eagle.ChangeState(State.Idle);
            }
        }
    }

    private class AttackState : EagleState
    {
        public AttackState(Eagle eagle) : base(eagle)
        {
        }

        public override void Update()
        {
            // Attack �ൿ�� ����
            Debug.Log("����");

            if (Vector2.Distance(eagle.transform.position, eagle.player.transform.position) > eagle.attackRange)
            {
                eagle.ChangeState(State.Trace);
            }
        }
    }

    private class DeadState : EagleState
    {
        public DeadState(Eagle eagle) : base(eagle)
        {
        }
    }


    #region BaseStatePattern
    /*
    private void Idle()
    {
        // Idle �ൿ�� ����
        // ������ �ֱ�

        // �ٸ� ���·� ��ȯ
        if (Vector2.Distance(transform.position, player.transform.position) < traceRange)
        {
            curState = State.Trace;
        }
    }

    private void Trace()
    {
        // Trace �ൿ�� ����
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        // �ٸ� ���·� ��ȯ
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
        // Return �ൿ�� ����
        transform.position = Vector2.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, startPos) < 0.01f)
        {
            curState = State.Idle;
        }
    }

    private void Attack()
    {
        // Attack �ൿ�� ����
        Debug.Log("����");

        if (Vector2.Distance(transform.position, player.transform.position) > attackRange)
        {
            curState = State.Trace;
        }
    }

    private void Dead()
    {
        // Dead �ൿ�� ����
        Debug.Log("����");
    }
    */
    #endregion
}
