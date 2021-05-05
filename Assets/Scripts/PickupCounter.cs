using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class PickupCounter : MonoBehaviour
{
   //public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject goal;
    public AudioSource audioS;
    public AudioClip pickup;
    public AudioMixerSnapshot ambLab;
    public AudioMixerSnapshot ambSilence;
 

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        setCountText();
        winTextObject.SetActive(false);
        goal = GameObject.FindGameObjectWithTag("Goal");
        goal.SetActive(false);
    }


    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
            {
            goal.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            audioS.PlayOneShot(pickup);
            other.gameObject.SetActive(false);
            count = count + 1;
            setCountText();
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            winTextObject.SetActive(true);
            count = 1;
        }

        if (other.CompareTag("Lab"))
        {
            ambLab.TransitionTo(0.5f);
        }

    }

}




