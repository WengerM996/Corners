using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class Dragging : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _offsetZ;

    private Figure _figure;
    private Coroutine _coroutine;
    private bool _dragging;
    private Camera _camera;
    private Vector3 _oldPosition;
    private Vector3 _newPosition;

    public event UnityAction Begin;
    public event UnityAction Ended;

    public static event UnityAction Moved;

    private void Awake()
    {
        _figure = GetComponent<Figure>();
    }

    private void Start()
    {
        _camera = Camera.main;

        _newPosition = transform.position;
    }

    public void SetPosition(Vector3 position)
    {
        _newPosition = position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_figure.Player.Moving) return;
        
        if (_coroutine == null)
        {
            _dragging = true;
            _oldPosition = transform.position;
            _coroutine = StartCoroutine(Moving());
            
            Begin?.Invoke();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_figure.Player.Moving) return;
        
        _dragging = false;

        if (_oldPosition != _newPosition)
        {
            Moved?.Invoke();
        }
        
        transform.position = _newPosition;
        
        Ended?.Invoke();
    }

    private IEnumerator Moving()
    {
        while (_dragging)
        {
            var distance = transform.position.z - _camera.transform.position.z;
            var position = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
            position.z = _offsetZ;
            transform.position = position;
            
            yield return new WaitForEndOfFrame();
        }

        _coroutine = null;
    }
}
