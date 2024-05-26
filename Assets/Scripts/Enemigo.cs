using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private int vidaEnemigo;
    private Animator animator;
    private float frecAtaque = 2.5f, tiempoSigAtaque = 0, iniciaConteo;

    public Transform personaje;
    private NavMeshAgent agente;
    public Transform[] puntosRuta;
    private int indiceRuta = 0;
    private bool playerEnRango = false;
    [SerializeField] private float distanciaDeteccionPlayer;
    private SpriteRenderer spriteEnemigo;
    private Transform mirarHacia;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        spriteEnemigo = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;

        for (int i = 0; i < puntosRuta.Length; i++)
        {
            puntosRuta[i].position += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        }
    }


    private void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        float distancia = Vector3.Distance(personaje.position, this.transform.position);

        if (agente.remainingDistance < 0.1f)
        {
            if (indiceRuta < puntosRuta.Length - 1)
            {
                indiceRuta++;
            }
            else if (indiceRuta == puntosRuta.Length - 1)
            {
                indiceRuta = 0;
            }
        }

        if (distancia < distanciaDeteccionPlayer)
        {
            playerEnRango = true;
        }
        else
        {
            playerEnRango = false;
        }

        if (tiempoSigAtaque > 0)
        {
            tiempoSigAtaque = frecAtaque + iniciaConteo - Time.time;
        }
        else
        {
            tiempoSigAtaque = 0;
            VidasPlayer.puedePerderVida = 1;
            SigueAlPlayer(playerEnRango);
            RotaEnemigo();
        }
    }

    private void SigueAlPlayer(bool playerEnRango)
    {
        if (playerEnRango)
        {
            agente.SetDestination(personaje.position);
            mirarHacia = personaje;
        }
        else
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
            mirarHacia = puntosRuta[indiceRuta];
        }
    }


    private void RotaEnemigo()
    {
        if (this.transform.position.x > mirarHacia.position.x)
        {
            spriteEnemigo.flipX = true;
            Debug.Log("FlipX");
        }
        else
        {
            spriteEnemigo.flipX = false;
            Debug.Log("Sin FlipX");
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            tiempoSigAtaque = frecAtaque;
            iniciaConteo = Time.time;
            obj.transform.GetComponentInChildren<VidasPlayer>().TomarDaño(1);
            ControladorSonido.Instance.EjecutarSonido(clip);
        }

    }

    public void TomarDaño(int daño)
    {
        vidaEnemigo -= daño;
        if (vidaEnemigo <= 0)
        {
            Morir();
        }
    }

   private void Morir()
    {
        // Notifica al contador de muertes
        if (ContadorEnemigos.Instance != null)
        {
            ContadorEnemigos.Instance.ContarEnemigo(1);
        }
        Destroy(gameObject);
    }
}