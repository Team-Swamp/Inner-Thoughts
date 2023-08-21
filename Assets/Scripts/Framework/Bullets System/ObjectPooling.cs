using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject[] activeBullets;
    [SerializeField] private GameObject[] inactiveBullets;
}
