using UnityEngine;

public class Key : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetKey()
    {
        Destroy(this.gameObject);
        Debug.Log("pegou a chave");
    }
}