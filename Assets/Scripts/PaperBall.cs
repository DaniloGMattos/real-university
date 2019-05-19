using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaperBall : MonoBehaviour
{
    protected virtual void Start()
    {
        
    }

  public Rigidbody2D rb;
  public Rigidbody2D hook;
  public float releaseTime = .15f;
  public float maxDragDistance = 5f;
  private bool isPressed = false;
    public GameObject nextBall;


  void Update()
  {
    if (isPressed)
    {
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
      {
        rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
      }
      else
      {
        rb.position = mousePos;
      }

    }
  }
  void OnMouseDown()
  {
        AudioManager.Play(gameObject, AudioManager.ENUMAudioFile.clique);
        isPressed = true;
    rb.isKinematic = true;
  }
  void OnMouseUp()
  {
    isPressed = false;
    rb.isKinematic = false;

    StartCoroutine(Release());
  }
  IEnumerator Release()
  {
        AudioManager.Play(gameObject, AudioManager.ENUMAudioFile.objtpequenovoando);
        yield return new WaitForSeconds(releaseTime);


    GetComponent<SpringJoint2D>().enabled = false;
    this.enabled = false;
        yield return new WaitForSeconds(2f);
       if(nextBall != null)
        {
            nextBall.SetActive(true);
       }
       else
        {
           SceneManager.LoadScene(3);
       }
        
  }
}