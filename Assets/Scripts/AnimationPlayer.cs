using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] Animator animPlayer;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animPlayer.SetBool("Andar", true);
        }
        else
        {
            animPlayer.SetBool("Andar", false);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animPlayer.SetBool("Correr", true);
        }
        else
        {
            animPlayer.SetBool("Correr", false);
        }


        if (Input.GetKey(KeyCode.S))
        {
            animPlayer.SetBool("AndarTras", true);
        }
        else
        {
            animPlayer.SetBool("AndarTras", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animPlayer.SetTrigger("Pular");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animPlayer.SetTrigger("Interact");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animPlayer.SetTrigger("Pegar");
        }

        if (Input.GetMouseButtonDown(0))
        {
            animPlayer.SetTrigger("Ataque");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
            animPlayer.SetBool("NoChao", true);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
            animPlayer.SetBool("NoChao", false);
    }
}
