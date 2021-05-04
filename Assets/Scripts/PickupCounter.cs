using UnityEngine;
using TMPro;

public class PickupCounter : MonoBehaviour
{
   //public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
 
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        setCountText();
        winTextObject.SetActive(false);
    }


    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
            {
            winTextObject.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }
    }

}
