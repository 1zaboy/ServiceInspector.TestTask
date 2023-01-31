using TreeCollections;

namespace ServiceInspector.Tasks.Tree;

public class ValueNode : SerialTreeNode<ValueNode>
{
    public int Value { get; set; }
    
    public ValueNode(int value, params ValueNode[] children) : base(children)
    {
        Value = value;
    }

    public ValueNode() : base(new ValueNode[] {})
    {
        throw new NotImplementedException();
    }
}