using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GraftItems : MonoBehaviour
{
    #region Veriables

    [SerializeField] private Rigidbody2D[] _prefabItems;
    private float screen = Screen.width / 54f/2f;
    
    #endregion

    #region Unity lifecycle

    private void Start()
    {
        ResetGravity();
        IEnumerator craftItems = createItems();
        IEnumerator gravityUp = gravityScaleUp();
        StartCoroutine(craftItems);
        StartCoroutine(gravityUp);
        Debug.Log(screen);
    }

    #endregion

    #region private Methods

    private IEnumerator createItems()
    {
        while (true)
        {
            CreateItems();
            yield return null;
        }
    }

    private IEnumerator gravityScaleUp()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            GravityScaleUp();
            yield return new WaitForSeconds(3);
        }
    }

    

    private void CreateItems()
    {
        int indexPrefab;
        float randomChance = Random.Range(-screen, screen);
        float randomChance1 = Random.Range(0f, 100f);
        if (randomChance1 > 70)
        {
            indexPrefab = 0;
        }
        else if (randomChance1 > 40)
        {
            indexPrefab = 2;
        }
        else if (randomChance1 > 10)
        {
            indexPrefab = 3;
        }
        else
        {
            indexPrefab = 1;
        }

        Vector3 currentPosition = transform.position;
        currentPosition.x = randomChance;
        transform.position = currentPosition;
        Instantiate(_prefabItems[indexPrefab], transform.position, Quaternion.identity);
    }

    private void GravityScaleUp()
    {
        foreach (Rigidbody2D rigidbody2D in _prefabItems)
        {
            rigidbody2D.gravityScale += 0.5f;
        }
    }

    private void ResetGravity()
    {
        foreach (Rigidbody2D rigidbody2D in _prefabItems)
        {
            rigidbody2D.gravityScale = 1f;
        }
    }
    #endregion
}