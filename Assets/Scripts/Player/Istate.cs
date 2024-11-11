using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Istate  
{

    void EnterState();
    void ExitState();
    void UpdateState();
}
