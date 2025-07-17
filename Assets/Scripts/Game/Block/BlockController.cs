using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private PoolObjects<Block> _poolObjects;
    [SerializeField] private int _startCountBlocksInPool;
    [SerializeField] private Block _prefabBlock;

    private List<Block> _allBlocksInPool = new List<Block>();

    [SerializeField] private GameUIManager _gameUIManager;

    public enum ControlType
    {
        PC,
        Mobile
    }
    
    public ControlType controlType;

    [Header("Sounds")]
    [SerializeField] private AudioSource _createBlockSound;
    [SerializeField] private AudioSource _destroyBlockSound;

    private void Awake()
    {
        _poolObjects = new PoolObjects<Block>(_prefabBlock, null, _startCountBlocksInPool);
    }

    private void Start()
    {
        if (controlType == ControlType.PC) _gameUIManager.OffControllButtons();
        if (controlType == ControlType.Mobile) _gameUIManager.OnControllButtons();
        StartCoroutine(ReturnBlocksInPool());
    }

    private void Update()
    {
        if (controlType == ControlType.PC)
        {
            if (Input.GetMouseButtonDown(0)) DestroyBlock();
            if (Input.GetMouseButtonDown(1)) BuildBlock();
        }
    }

    // For PC device
    private void BuildBlock()
    {
        if(transform.position.y < 4)
        {
            _createBlockSound.Play();
            transform.position += Vector3.up;
            Block block = _poolObjects.Get();
            block.gameObject.SetActive(false);
            block.rb.velocity = Vector3.zero;
            block.transform.position = transform.position + Vector3.down;
            block.gameObject.SetActive(true);
            _allBlocksInPool.Add(block);
        }
    }

    private void DestroyBlock()
    {
        if (_allBlocksInPool.Count == 0) return;
        if (transform.position.y > -2)
        {
            _destroyBlockSound.Play();
            Block lastBlock = _allBlocksInPool[^1];
            _allBlocksInPool.Remove(_allBlocksInPool[^1]);
            _poolObjects.Realese(lastBlock);
        }
    }

    private IEnumerator ReturnBlocksInPool()
    {
        WaitForSeconds _secondsForReturn = new WaitForSeconds(7);
        while (true)
        {
            yield return _secondsForReturn;
            if(_allBlocksInPool.Count > 0)
            {
                _poolObjects.Realese(_allBlocksInPool[0]);
                _allBlocksInPool.Remove(_allBlocksInPool[0]);
            }
        }
    }

    // For Mobile device
    public void BuildBlockButton()
    {
        BuildBlock();
    }

    public void DestroyBlockButton()
    {
        DestroyBlock();
    }
}
