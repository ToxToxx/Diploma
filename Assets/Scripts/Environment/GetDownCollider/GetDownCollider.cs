using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetDownCollider : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_playerLayerMask == (_playerLayerMask | (1 << collision.gameObject.layer)))
        {

            SceneManager.LoadScene("SampleScene");
        }
    }
}
