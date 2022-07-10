namespace Star;

public enum BTreeMixin_BTreeImpl_ModifyState
{
    LeafNeedsJoin=0,
    IndexNeedsJoin=1,
    LeafSplit=2,
    IndexSplit=3,
    LeafNeedsUpdate=4,
    IndexNeedsUpdate=5,
    Done=6
}
