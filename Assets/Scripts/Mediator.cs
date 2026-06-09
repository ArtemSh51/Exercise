using UnityEngine;

public class Mediator : MonoBehaviour
{
    [SerializeField] private CubeRecipient _recipient;
    [SerializeField] private Creater _creater;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Remover _remover;

    private void OnEnable()
    {
        _recipient.ButtonPressed += _creater.CreateNewCubes;
        _creater.CubesCreated += _exploder.BlowUp;
        _creater.CreationFailed += _remover.RemoveCube;
        _exploder.CubesExploded += _remover.RemoveCube;
    }

    private void OnDisable()
    {
        _recipient.ButtonPressed -= _creater.CreateNewCubes;
        _creater.CubesCreated -= _exploder.BlowUp;
        _creater.CreationFailed -= _remover.RemoveCube;
        _exploder.CubesExploded -= _remover.RemoveCube;
    }
}
