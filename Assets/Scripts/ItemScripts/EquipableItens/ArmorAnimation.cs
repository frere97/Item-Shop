using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmorAnimation : MonoBehaviour
{
    public LocalPlayer localPlayer;
    [SerializeField] Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        localPlayer = transform.parent.GetComponent<LocalPlayer>();
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", localPlayer.GetPlayerMovement().x);
        animator.SetFloat("Vertical", localPlayer.GetPlayerMovement().y);
        animator.SetFloat("Speed", localPlayer.speed);
    }



}
