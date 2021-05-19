using UnityEngine;

public class MatchEntity : MonoBehaviour
{
    public MatchFeedback _feedback;
    public MovablePair _movablePair;
    public Renderer _fixedPairRenderer;
    public MatchEntityManager _matchSystemController;

    private bool _matched;

    public Vector3 GetMovablePairPosition()
    {
        return _movablePair.GetPosition();
    }

    public void SetMovablePairPosition(Vector3 NewMovablePairPosition)
    {
        _movablePair.SetInitialPosition(NewMovablePairPosition);
    }
    
    //Set the paired the sme material
    public void SetMaterialToPairs(Material PairMaterial)
    {
        _movablePair.GetComponent<Renderer>().material = PairMaterial;
        _fixedPairRenderer.material = PairMaterial;
    }

    //IsEnter is the bool to show that the object is in port or not.
    public void PairObjectInteraction(bool IsEnter, MovablePair movable)
    {
        if (IsEnter && !_matched)
        {
            //Set to movable if the movable match with movable pair
            _matched = (movable == _movablePair);
            if (_matched)
            {
                _matchSystemController.NewMatchRecord(_matched);
                _feedback.ChangeMaterialWithMatch(_matched);
            }
        }
        else if(!IsEnter && _matched)
        {
            //opposite of ^
            _matched = !(movable == _movablePair);
            if (_matched)
            {
                _matchSystemController.NewMatchRecord(_matched);
                _feedback.ChangeMaterialWithMatch(_matched);
            }
        }
        
    }


}
