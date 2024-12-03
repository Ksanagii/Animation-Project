using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator animChest;
    [SerializeField] private bool open;
    [SerializeField] GameObject key;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        open = false;
    }
    void Start()
    {
        animChest = GetComponent<Animator>();
    }

    public void OpenChest()
    {
        animChest.SetTrigger("Open");
        open = true;
        GetKey();
    }
    public bool CloseChest()
    {
        return open;
    }
    public void GetKey()
    {
        Vector3 bauPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z);
        Instantiate(key, bauPos, Quaternion.identity);
       
    }

}
