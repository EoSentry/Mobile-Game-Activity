using Ebac.Core.singleton;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class LevelManager : Singleton<LevelManager>
{
    public Transform container;

    public List<LevelPieceBaseSetup> levelPieceBaseSetups;

    public float timeBetweenPieces = .3f;
    

    [SerializeField]private int _index;
    private GameObject _currtLevel;

    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBaseSetup _currentSetup;

    /* protected override void Awake()
     {
         base.Awake();
         CreateLevelPieces();
     }*/

    public void Start()
    {
        CreateLevelPieces();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            CreateLevelPieces();
        }
    }


    #region Métodos do Manager
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

         for(int i = 0; i < _currentSetup.piecesStartNumber; i++)
        {
            CreateLevelPiece(_currentSetup.startPieces);
        }


        for(int i = 0; i < _currentSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currentSetup.pieces);
        }

        for(int i = 0; i < _currentSetup.piecesEndNumber; i++)
        {
            CreateLevelPiece(_currentSetup.endPieces);
        }

        ColorManager.Instance.ChangeColorByType(_currentSetup.artType);

    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogError("LISTA NULA OU VAZIA");
            return;
        }

        var pieces = list[Random.Range(0, list.Count)];
        var spawnedPieces = Instantiate(pieces, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPieces.transform.position = lastPiece.endPiece.position;
        }

        else
        {
            spawnedPieces.transform.localPosition = Vector3.zero;
        }

        foreach(var p in spawnedPieces.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currentSetup.artType).gameObject);
        }

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
    #endregion
    //
}
