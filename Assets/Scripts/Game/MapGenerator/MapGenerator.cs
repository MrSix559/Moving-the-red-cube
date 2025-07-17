using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private List<PoolObjects<Chunk>> _poolList = new();
    private (Chunk, int)[] _activeChunks = new (Chunk, int)[2];
    [SerializeField] private Transform _startChunkSpawnPos;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _parentForChunks;
    [SerializeField] private Chunk[] _prefabChunks;

    private void Awake()
    {
        foreach (var prefab in _prefabChunks)
            _poolList.Add(new PoolObjects<Chunk>(prefab, _parentForChunks, 3));

        _activeChunks[0] = CreateChunk();
        _activeChunks[0].Item1.transform.position = _startChunkSpawnPos.position;
        _activeChunks[1] = CreateChunk();
        _activeChunks[1].Item1.transform.position = _activeChunks[0].Item1.end.position;
    }

    private void Update()
    {
        if(_player.position.x > _activeChunks[1].Item1.pivot.position.x)
            SpawnChunk();
    }

    private (Chunk, int) CreateChunk()
    {
        int randChunk = Random.Range(0, _poolList.Count);
        Chunk chunk = _poolList[randChunk].Get();
        return (chunk, randChunk);
    }

    private void SpawnChunk()
    {
        _poolList[_activeChunks[0].Item2].Realese(_activeChunks[0].Item1);
        _activeChunks[0] = _activeChunks[1];
        _activeChunks[1] = CreateChunk();
        _activeChunks[1].Item1.transform.position = _activeChunks[0].Item1.end.position;
    }
}
