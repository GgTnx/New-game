using System;
using UnityEngine;

public class platform : MonoBehaviour
{
    #region Unity Lifecycle

    private void Update()
    {
        MovePlatformWithmouse();
    }

    #endregion


    #region Private methods

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Tags.Add))
        {
            GameManager.Instanse.AddScore();
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag(Tags.Remove))
        {
            GameManager.Instanse.RemoveScore();
            Destroy(col.gameObject);
        }
        else
        {
        }
    }

    private void MovePlatformWithmouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 currentPosition = transform.position;
        currentPosition.x = worldPosition.x;
        transform.position = currentPosition;
    }

    #endregion
}