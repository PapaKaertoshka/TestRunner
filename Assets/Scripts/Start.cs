using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject progressBar;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator anim;

    public void CloseMenu()
    {
        startMenu.SetActive(false);
        progressBar.SetActive(true);
        player.SetActive(true);
        anim.SetBool("Start", true);
    }
}
