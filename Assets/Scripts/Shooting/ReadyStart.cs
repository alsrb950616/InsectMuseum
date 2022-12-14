using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyStart : MonoBehaviour
{
    [SerializeField] private ShootingMode _shootingMode = null;

    void StartGame()
    {
        _shootingMode.onAnimationEnvent();
    }
}
