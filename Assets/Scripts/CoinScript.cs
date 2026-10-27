using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //The player calls this function on the coin whenever they bump into it
    //You can change its contents if you want something different to happen on collection
    //For example, what if the coin teleported to a new location instead of being destroyed?
    public void GetBumped()
    {
        //This destroys the coin
        //Destroy(gameObject);
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);

        if (x >= 3f && x <= 5f && y >= -3f && y <= 3f)
        {
            if (Random.Range(0, 2) == 0)
            {
                x = Random.Range(-8f, 3f);
            }
            else
            {
                x = Random.Range(5f, 8f);
            }
        }
        transform.position = new Vector3(x, y, 0f);
        Debug.Log("Coin bumped! New position: " + transform.position);
    }
}
