using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Ebac.Core.singleton;

public class LevelManager : Singleton<LevelManager>
{
    public Transform container;

    public List<LevelPieceBaseSetup> levelPieceBaseSetups;

    public float timeBetweenPieces = .3f;

    [SerializeField]private int _index;
    private GameObject _currtLevel;

    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBaseSetup _currentSetup;

    private void ResetLevelIndex()
    {
        _index = 0;
    }


    private void CreateLevelPieces()
    {
        CleanSpawnedPieces();
        if(_currentSetup != null)
        {
            _index++;
            if(_index >= levelPieceBaseSetups.Count)
                ResetLevelIndex();
        }
        _currentSetup = levelPieceBaseSetups[_index];

        for(int i = 0; i < _currentSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currentSetup.pieces);
        }

        for(int i = 0; i < _currentSetup.piecesEndNumber; i++)
        {
            CreateLevelPiece(_currentSetup.endPieces);
        }



    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var pieces = list[Random.Range(0, list.Count)];
        var spawnedPieces = Instantiate(pieces, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPieces.transform.localPosition = lastPiece.endPiece.position;
        }

        else
        {
            spawnedPieces.transform.localPosition = Vector3.zero;
        }

        //foreach(var p in spawnedPieces.GetComponentsInChildren)

        _spawnedPieces.Add(spawnedPieces);
    }



    private void CleanSpawnedPieces()
    {
        for(int i = _spawnedPieces.Count -1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }
        _spawnedPieces.Clear();
    }

}
