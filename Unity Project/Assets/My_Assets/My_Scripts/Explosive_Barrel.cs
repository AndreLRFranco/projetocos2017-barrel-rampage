﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;


public class Explosive_Barrel : MonoBehaviour
{
    public GameObject m_ExplosionPrefab;
    public bool isShot;
    public ParticleSystem m_ExplosionParticles;

    void Awake()
    {
        gameObject.SetActive(true);
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionParticles.gameObject.SetActive(false);
    }

    private void Start()
    {
        isShot = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name.Contains("SMGShot") && isShot == false)
        {
            isShot = true;
            m_ExplosionParticles.transform.position = transform.position;
            m_ExplosionParticles.gameObject.SetActive(true);
            m_ExplosionParticles.Play();
            if (coll.gameObject.tag == "P1")
            {
                GameManager.managerInstance.playerOnePointUp();
            }
            else if (coll.gameObject.tag == "P2")
            {
                GameManager.managerInstance.playerTwoPointUp();
            }
            GameManager.managerInstance.m_ActiveBarrels--;
            gameObject.SetActive(false);
        }
    }

    public void ResetBarrel()
    {
        gameObject.SetActive(true);
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionParticles.gameObject.SetActive(false);
    }

}
