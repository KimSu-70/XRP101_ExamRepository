using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    private AudioSource _audio;
    [SerializeField] GameObject body;
    [SerializeField] Collider collider;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // 사운드가 재생되고 바디 오브젝트 비활성화 및 콜라이더 비활성화
        _audio.Play();
        body.SetActive(false);
        collider.enabled = false;
    }
}
