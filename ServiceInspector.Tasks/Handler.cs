using ServiceInspector.Tasks.Tree;
using TreeCollections;

namespace ServiceInspector.Tasks;

public class Handler
{
    private List<int> m_Array;
    private ReadOnlyEntityTreeNode<int, ValueNode> m_TreeRoot;

    public Handler(params int[] array)
    {
        m_Array = new List<int>(array);
        m_TreeRoot = new ReadOnlyEntityTreeNode<int, ValueNode>(
            x => x.Value,
            new ValueNode(0, InitTree(m_Array).ToArray())
        );
    }

    private List<ValueNode> InitTree(IReadOnlyList<int> values)
    {
        var res = new List<ValueNode>();

        foreach (var value in values)
        {
            var list = new List<int>(values);
            list.Remove(value);
            res.Add(new ValueNode(value, InitTree(list).ToArray()));
        }

        return res;
    }

    public IEnumerable<int> GetArrayForSum(int value)
    {
        return FindSum(m_TreeRoot.Item, new List<int>(), value).Where(x => x >= 1);
    }

    private List<int> FindSum(ValueNode node, List<int> list, int value)
    {
        var resultList = new List<int>(list);
        
        resultList.Add(node.Value);
        
        if (resultList.Sum() == value) return resultList;
        if (resultList.Sum() > value) return new List<int>();

        foreach (var nodeChild in node.Children)
        {
            var findSum = FindSum(nodeChild, resultList, value);
            if (findSum.Any()) return findSum;
        }

        return new List<int>();
    }
}