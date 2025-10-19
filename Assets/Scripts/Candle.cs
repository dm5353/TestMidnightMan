using System.Collections;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] private GameObject[] candleParts;

    [SerializeField] private GameObject hand;

    private bool isWind = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CandleFire(true);
            isWind = false;
        }

        if (!Input.GetKey(KeyCode.E))
            hand.SetActive(false);
        else
        {
            isWind = false;
            hand.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!Input.GetKey(KeyCode.E))
        {
            if (other.gameObject.tag == "Wind" && !isWind)
            {
                isWind = true;
                StartCoroutine(WaitSeconds(5f));
            }
            else if (other.gameObject.tag == "Water")
                CandleFire(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wind")
            isWind = false;
    }

    private IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Debug.Log(11);

        if (isWind)
            CandleFire(false);
    }

    private void CandleFire(bool active)
    {
        foreach (GameObject candlePart in candleParts)
        {
            candlePart.SetActive(active);
        }
    }
}
