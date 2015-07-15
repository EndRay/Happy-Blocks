﻿using System;
using UnityEngine;

public class Creator : MonoBehaviour
{
    private Quaternion _dragedObjQ;

    private GameObject _dragedObj;

    public Material[] Grass;

    public Sprite[] Background;

    public AudioSource[] Music;

    private readonly Vector2[] _gravity = new []
    {
        Vector2.up * -3,
        Vector2.up * -10 
    };

    public GameObject GrassObj;

    public GameObject BackgroundQuad;

    public bool Delete;

    public Camera Camera;

    public GameObject[] Cubes;

    public bool Rotate = false;

    public bool IsSun = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("mouse 0"))
	    {
            RaycastHit hit;
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, 1 << 9) && !Delete && _dragedObj == null)
            {
                var hitObj = hit.transform.gameObject;
                hitObj = hitObj.transform.parent.gameObject;
                _dragedObj = hitObj;
                _dragedObj.GetComponent<Rigidbody2D>().angularVelocity = 0;
                _dragedObjQ = _dragedObj.transform.rotation;
            }
            if (Physics.Raycast(ray, out hit, 100f, 1 << 8) && !Delete && _dragedObj != null)
            {
                //_dragedObj.transform.rotation = _dragedObjQ;
                _dragedObj.GetComponent<Rigidbody2D>().velocity = (hit.point - _dragedObj.transform.position) * 20;
            }
	        if (_dragedObj != null)
	        {
                RaycastHit alignHit;
                if (Physics.Raycast(_dragedObj.transform.position, -Vector3.up, out alignHit, 100f, 1 << 10))
                {
                    var hitObj = alignHit.transform.parent; 
                    var differens = hitObj.transform.position - _dragedObj.transform.position;
                    if (Mathf.Abs(differens.x) < 0.5 && Mathf.Abs(differens.y) < 3)
                    {
                        _dragedObj.transform.position = new Vector3(hit.transform.position.x,
                            _dragedObj.transform.position.y, 4);
                    }
                }
	            if (Math.Abs(Input.GetAxis("Horizontal")) < 0.1)
                {
                    _dragedObj.GetComponent<Rigidbody2D>().angularVelocity = 0;
                    _dragedObj.transform.rotation = _dragedObjQ;
                }
                else
                {
                    _dragedObj.GetComponent<Rigidbody2D>().angularVelocity = Input.GetAxis("Horizontal") * -100;
                    _dragedObjQ = _dragedObj.transform.rotation;
                }   
	        }
	        if (Physics.Raycast(ray, out hit, 100f, 1 << 9) && Delete)
	        {
	            var hitObj = hit.transform.gameObject;
	            hitObj = hitObj.transform.parent.gameObject;
	            Destroy(hitObj);
	        }
	    }
	    else
	    {
	        if (_dragedObj != null)
	        {
                
                _dragedObj.GetComponent<Rigidbody2D>().velocity /= 3;
                _dragedObj.GetComponent<Rigidbody2D>().angularVelocity = 0;
	        }
            _dragedObj = null;
	    }
	}

    public void SunChange()
    {
        IsSun = !IsSun;
        GrassObj.GetComponent<Renderer>().material = Grass[IsSun ? 1 : 0];
        BackgroundQuad.GetComponent<SpriteRenderer>().sprite = Background[IsSun ? 1 : 0];
        Music[IsSun ? 0 : 1].GetComponent<AudioSource>().Stop();
        Music[IsSun ? 1 : 0].GetComponent<AudioSource>().Play();
        Physics2D.gravity = _gravity[IsSun ? 1 : 0];
    }
}
