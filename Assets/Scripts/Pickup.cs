using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Rendering;

public class Pickup : MonoBehaviour
{
    public float speed;
    public bool isActivated;

    private void Update()
    {
        if (!isActivated)
        {
            transform.eulerAngles += new Vector3(0, speed, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = true;

            Sequence s = DOTween.Sequence();
            s.Append(transform.DORotate(Vector3.zero, .3f));

            s.Append(transform.DORotate(new Vector3(0,0,-900), 2f, RotateMode.LocalAxisAdd));

            s.Join(transform.DOScale(0, .5f).SetDelay(1f));

            s.AppendCallback(() =>
            {
                PickUp(10);
                Destroy(gameObject);
            }
            );

        void PickUp(float health)
        {
            //healthmanager.Heal(health);
            //Destroy(gameObject);

        }


            //Gehitu objetu hau hartzen duzuenean gertztzen dena, zuen logika.
        }
    }
}
