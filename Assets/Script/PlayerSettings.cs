using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Player Settings", menuName = "PlayerData/Player Settings")]

public class PlayerSettings : ScriptableObject
{
    public float speed = 12f;
    public float gravity = -8.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
}
