﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerController : MonoBehaviour
{
    public static SPlayerController instance;
    public float moveSpeed;
    public Rigidbody2D theRB;
    public Transform bottomLeftLimit, topRightLimit;
    public Transform shotPoint;
    public GameObject shot;
    public float timeBetweenShots = .1f;
    private float ShotsCounter; 
    private float normalSpeed;
    public float boostSpeed;
    public float boostTime;
    private float boostCounter;
    public bool doubleShotActive;
    public float doubleShotOffset;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
    }
    void Start()
    {   
        normalSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y), transform.position.z);
            
            if(Input.GetButtonDown("Fire1"))
            {
            if(!doubleShotActive)
            {
                Instantiate(shot, shotPoint.position, shotPoint.rotation);
            }else
            {
              Instantiate(shot, shotPoint.position + new Vector3(0f, doubleShotOffset, 0f), shotPoint.rotation);
              Instantiate(shot, shotPoint.position - new Vector3(0f, doubleShotOffset, 0f), shotPoint.rotation);

            }
        
                
                ShotsCounter = timeBetweenShots;
            }

            if(Input.GetButton("Fire1"))
            {
                ShotsCounter -= Time.deltaTime;
                if(ShotsCounter <=0)
                {
                  if(!doubleShotActive)
            {
                Instantiate(shot, shotPoint.position, shotPoint.rotation);
            }else
            {
              Instantiate(shot, shotPoint.position + new Vector3(0f, doubleShotOffset, 0f), shotPoint.rotation);
              Instantiate(shot, shotPoint.position - new Vector3(0f, doubleShotOffset, 0f), shotPoint.rotation);

            }
                  ShotsCounter = timeBetweenShots;
                }

            }
            if(boostCounter > 0)
            {
                boostCounter -= Time.deltaTime;
                if(boostCounter <= 0)
                {
                    moveSpeed = normalSpeed;
                }
            }

    }
    public void ActivateSpeedBoost()
    {
        boostCounter = boostSpeed;
        moveSpeed = boostSpeed;
    }
}
