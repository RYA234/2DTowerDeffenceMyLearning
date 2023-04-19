using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static Action<Node> OnNodeSelected;
    public Turrets Turrets { get; set; }

    public void SetTurret(Turrets turrets)
    {
        Turrets = turrets;
    }

    public bool IsEmpty()
    {
        return Turrets == null;
    }

    public void SelectTurret()
    {
        OnNodeSelected?.Invoke(this);
    }
}
