using NUnit.Framework;

namespace ServiceInspector.Tasks.Test;

[TestFixture]
public class HandlerTest
{
    [Test]
    public void GetArrayByNumber10()
    {
        var handler = new Handler(new[] { 3, 1, 8, 5, 4 });
        var res = handler.GetArrayForSum(10).ToArray();
        CollectionAssert.AreEqual(new[] { 1, 5, 4 }, res);
    }

    [Test]
    public void GetArrayByNumber12()
    {
        var handler = new Handler(new[] { 3, 1, 8, 5, 4 });
        var res = handler.GetArrayForSum(12).ToArray();
        CollectionAssert.AreEqual(new[] { 3, 1, 8 }, res);
    }

    [Test]
    public void GetArrayByNumber17()
    {
        var handler = new Handler(new[] { 3, 1, 8, 5, 4 });
        var res = handler.GetArrayForSum(17).ToArray();
        CollectionAssert.AreEqual(new[] { 3, 1, 8, 5 }, res);
    }
}