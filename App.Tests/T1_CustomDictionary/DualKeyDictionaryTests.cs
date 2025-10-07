using App.T1_CustomDictionary;

namespace App.Tests.T1_CustomDictionary;

[TestFixture]
public class DualKeyDictionaryTests
{
    [Test]
    public void SetAndGet_ByIntKey_Works_For_ReferenceType()
    {
        var dict = new DualKeyDictionary<string>();
        dict[42] = "answer";
        Assert.That(dict[42], Is.EqualTo("answer"));

        dict[42] = "updated";
        Assert.That(dict[42], Is.EqualTo("updated"));
    }

    [Test]
    public void SetAndGet_ByStringKey_Works_For_ValueType()
    {
        var dict = new DualKeyDictionary<int>();
        dict["count"] = 10;
        Assert.That(dict["count"], Is.EqualTo(10));

        dict["count"] = -5;
        Assert.That(dict["count"], Is.EqualTo(-5));
    }

    [Test]
    public void Get_Unknown_Int_Key_Throws()
    {
        var dict = new DualKeyDictionary<string>();
        Assert.Throws<KeyNotFoundException>(() => { var _ = dict[777]; });
    }

    [Test]
    public void Get_Unknown_String_Key_Throws()
    {
        var dict = new DualKeyDictionary<int>();
        Assert.Throws<KeyNotFoundException>(() => { var _ = dict["nope"]; });
    }

    [Test]
    public void String_Key_Null_Throws_On_Get_And_Set()
    {
        var dict = new DualKeyDictionary<string>();
        Assert.Throws<ArgumentNullException>(() => { var _ = dict[null!]; });
        Assert.Throws<ArgumentNullException>(() => dict[null!] = "x");
    }

    [Test]
    public void Int_And_String_KeySpaces_Are_Independent()
    {
        var dict = new DualKeyDictionary<string>();
        dict[1] = "one";
        dict["1"] = "string-one";

        Assert.That(dict[1], Is.EqualTo("one"));
        Assert.That(dict["1"], Is.EqualTo("string-one"));
    }
}
