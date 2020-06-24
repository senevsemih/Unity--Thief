using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [Header("References")]
    public Transform target;
    public GameObject textPrice;

    [Header("Attributes")]
    public int price;

    private Rigidbody rigidb;
    private readonly float speed = 100f;
    private bool isLooting = false;
    private readonly float duration = 2.5f;

    private void Start()
    {
        rigidb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isLooting = true;

            if (isLooting)
            {
                MoneyCounter.instance.TotalMoney(price);

                StartCoroutine(Scaling());

                InvokeRepeating("Movement", 0f, 0.1f);

                ValueText();
            }

        }
    }
    void Movement()
    {
        Vector3 direciton = (target.position - transform.position).normalized;
        rigidb.velocity = (direciton * Time.deltaTime * speed);
    }
    void ValueText()
    {
        GameObject damageText = Instantiate(textPrice, transform.position, Quaternion.Euler(45, 0, 0), transform);
        damageText.GetComponent<TextMesh>().text = price.ToString() + " $";
    }
    IEnumerator Scaling()
    {
        float timer = 0f;
        while(timer < duration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, timer / duration);
            
            yield return null;
        }
        transform.localScale = Vector3.zero;

        Destroy(this.gameObject);   

        yield return new WaitForSeconds(0.1f);

        isLooting = false;
    }
}
