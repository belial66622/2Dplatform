using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detectdamage : MonoBehaviour
{
    float knockbackTime = .23f;

    [SerializeField]
    Control control;

    [SerializeField]
    Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {

            Vector3 forward = transform.TransformDirection(Vector3.up);
            Vector3 toOther = Vector3.Normalize(enemy.transform.position - transform.position);
            if (Vector3.Dot(forward, toOther) < -0.7f)
            {
                enemy.Death();
                Knock();

            }
            else
            {
                Knock(false);

                control.ControlBlock(true);
                StartCoroutine(death(2f));
            }
        }

        else if (collision.TryGetComponent<TongSampah>(out TongSampah tong))
        {
            tong.PindahLevel();
        }

        else if (collision.TryGetComponent<Immoveable>(out Immoveable trap))
        {
            Knock(false);

            control.ControlBlock(true);
            StartCoroutine(death(1f));
        }

    }

    private void Knock(bool condition = true)
    {
        StartCoroutine(KnockBack(condition));
    }

    IEnumerator KnockBack(bool condition)
    {
        control.ControlBlock(true);
        float time =0;
        while (knockbackTime > time)
        {
            transform.position += (-transform.right * Time.deltaTime*3) + (Vector3.up * Time.deltaTime*3);
            time += Time.deltaTime;
            yield return null;
        }
        if(condition)
        control.ControlBlock(false);
    }

    IEnumerator death(float t)
    {
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(t);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
