using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventry
{
    public string Name { get; }
    [SerializeField] public int NumberOfPossessions { get; }
    public Sprite Image { get; }
}
