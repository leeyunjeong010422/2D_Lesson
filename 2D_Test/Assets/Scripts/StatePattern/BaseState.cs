using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public virtual void Enter() { } //시작했을 때
    public virtual void Update() { } //동작 중일 때
    public virtual void Exit() { } //마무리 됐을 때
}
