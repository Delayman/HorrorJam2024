using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float _moveSpeed;
    [SerializeField]private float _laneMovedDistance = 2;
    

    private CharacterController _characterController;
    private Vector3 _direction;

    //0L 1M 2R
    private int currentLane = 1;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update() 
    {
        _direction.z = _moveSpeed;
        _moveSpeed += 0.2f * Time.deltaTime;
        

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(currentLane < 2) {currentLane++;}
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(currentLane > 0) {currentLane--;}
        }

        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;

        switch (currentLane)
        {
            case 0: targetPos += Vector3.left * _laneMovedDistance; break;
            case 2: targetPos += Vector3.right * _laneMovedDistance; break;
        }

        if(transform.position != targetPos) 
        {
            Vector3 diff = targetPos - transform.position;
            Vector3 moveDir = diff.normalized * 20f * Time.deltaTime;
            if(moveDir.sqrMagnitude < diff.magnitude)
            {
                _characterController.Move(moveDir);
            }else
            {
                _characterController.Move(diff);
            }
        }

        _characterController.Move(_direction * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        // Debug.Log(hit.gameObject.name);
        if(hit.transform.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
