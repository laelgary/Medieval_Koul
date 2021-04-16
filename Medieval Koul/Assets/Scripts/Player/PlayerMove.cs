using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //declarer les variables

    //velocité deplacement par defaut
    public float moveSpeed;

    //bouge ou pas
    private bool isMoving;

    //Vector est un objet venan de unity
    private Vector2 input;


    //fonction mise a jour de la page
    private void Update()
    {
        //recuperer la position si le player bouge pas 
        if (!isMoving)
        {

            //assignation des position x et y
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //enlever le mouvement diagonale
            if (input.x != 0) input.y = 0;


            if (input != Vector2.zero)
            {

                //destination
                var targetPos = transform.position;

                //l'axe horizontale du joueur s'ajoute au x de la destination 
                targetPos.x += input.x;
                //l'axe verticale du joueur s'ajoute au y de la destination 
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }


        }
    }


    //fonction Permettant de faire partir le joueur d'un point A à un point B dans une certaine periode de temps
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;


        //boucle faisant avancer petit a petit le joueur vers la destination, jusqu'a ce que la position et la destination soit la meme 
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //une fois la destination atteinte, cette condition deviens fausse et on sort de la boucle
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        //assigner la position actuelle du joueur a la destination
        transform.position = targetPos;

        isMoving = false;
    }

}
