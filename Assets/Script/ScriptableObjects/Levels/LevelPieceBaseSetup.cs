using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBaseSetup : ScriptableObject
{
    public ArtManager.ArtType artType;
    [Header("Pieces")]
    public List<LevelPieceBase> startPieces;
    public List<LevelPieceBase> pieces;
    public List<LevelPieceBase> endPieces;

    [Header("Ammount")]
    public int piecesStartNumber = 1;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
}
