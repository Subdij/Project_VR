using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _3rd_Party_Assets.Gun__Target.Scripts
{
    public class Target : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private BoxCollider _boxCollider;
        private AudioSource _audioSource;
        private ParticleSystem _particleSystem;

        private Vector3 _randomRotation;
        private bool _isDisabled;

        // Score
        private int LocalScore;
        public Text hiddenLocalText;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _boxCollider = GetComponent<BoxCollider>();
            _audioSource = GetComponent<AudioSource>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();

            _randomRotation = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));

        }

        private void Update() => Rotate();
        

        private void Rotate() => transform.Rotate(_randomRotation);

        private void OnCollisionEnter(Collision other)
        {
            if (!_isDisabled && other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                ToggleTarget();
                TargetDestroyEffect();
                Invoke("ToggleTarget", 3f);

                LocalScore++;
                hiddenLocalText.text = LocalScore.ToString();

            }

        }

        private void ToggleTarget()
        {
            _meshRenderer.enabled = _isDisabled;
            _boxCollider.enabled = _isDisabled;

            _isDisabled = !_isDisabled;
        }

        private void TargetDestroyEffect()
        {
            var random = Random.Range(0.8f, 1.2f);
            _audioSource.pitch = random;

            _audioSource.Play();
            _particleSystem.Play();
        }
    }
}