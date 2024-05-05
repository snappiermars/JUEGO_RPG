using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventario : MonoBehaviour
{
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inv;
    public bool Activar_inv;
    public GameObject Selector;
    public int ID;

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Item")){
            for (int i= 0; i < Bag.Count; i++){
                if (Bag[i].GetComponent<Image>().enabled == false)
                {
                    Bag[i].GetComponent<Image>().enabled = true;
                    Bag[i].GetComponent<Image>().sprite = coll.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
        }
    }

    public void Navegar(){
        if (Input.GetKeyDown(KeyCode.D) && ID < Bag.Count-1){
            ID++;
        }
        if (Input.GetKeyDown(KeyCode.A) && ID > 0){
            ID--;
        }
         if (Input.GetKeyDown(KeyCode.W) && ID > 6){
            ID-=7;
        }
         if (Input.GetKeyDown(KeyCode.S) && ID < 7){
            ID+=7;
        }
        Selector.transform.position = Bag[ID].transform.position;
    }

    void Start()
    {
        Activar_inv = false;
    }

    // Update is called once per frame
    void Update()
    {
        Navegar();
        if (Activar_inv)
        {
            Time.timeScale =0;
            inv.SetActive(true);            
        }else{
            Time.timeScale =1;
            inv.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E)){
            Activar_inv = !Activar_inv;
        }

    }
}
