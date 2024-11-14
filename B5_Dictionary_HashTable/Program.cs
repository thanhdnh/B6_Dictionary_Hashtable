using System.Collections;

public class IPAddress : DictionaryBase
{
    public void Add(string name, string ip)
    {
        base.InnerHashtable.Add(name, ip);
    }
    public string Item(string name)
    {
        return base.InnerHashtable[name].ToString();
    }
    public void Remove(string name)
    {
        base.InnerHashtable.Remove(name);
    }
}
public class BucketHash
{
    private const int SIZE = 10;
    ArrayList[] data;
    public BucketHash()
    {
        data = new ArrayList[SIZE];
        for (int i = 0; i <= SIZE - 1; i++)
            data[i] = new ArrayList(4);
    }
    public int Hash(string s)
    {//hash function
        long tot = 0;
        char[] chararray;
        chararray = s.ToCharArray();
        for (int i = 0; i <= s.Length - 1; i++)
            tot += 37 * tot + (int)chararray[i];
        tot = tot % data.GetUpperBound(0);
        if (tot < 0)
            tot += data.GetUpperBound(0);
        return (int)tot;
    }
    public void Insert(string item)
    {
        int hash_value = Hash(item);
        if (!data[hash_value].Contains(item))
            data[hash_value].Add(item);
    }
    public void Remove(string item)
    {
        int hash_value = Hash(item);
        if (data[hash_value].Contains(item))
            data[hash_value].Remove(item);
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        //---- Example for Dictionary
        IPAddress myips = new IPAddress();
        myips.Add("Mike", "192.151.0.1");
        myips.Add("David", "192.151.0.2");
        myips.Add("Bernica", "192.151.0.3");
        Console.WriteLine("IP cua Mike la: " + myips.Item("Mike"));
        Console.WriteLine("\nKey va value la:");
        IDictionaryEnumerator e = myips.GetEnumerator();
        while (e.MoveNext())
            Console.WriteLine("key={0},value={1}", e.Key, e.Value);

        //---- Example for Hashtable
        Hashtable infos = new Hashtable(5);
        infos.Add("salary", 100000);
        infos.Add("name", "David Job");
        infos.Add("age", 45);
        infos.Add("dept", "Information Technology");
        infos["gender"] = "Male";
        Console.WriteLine("\n\nKey: ");
        foreach (object key in infos.Keys)
            Console.WriteLine(key);
        Console.WriteLine("Value:");
        foreach (object value in infos.Values)
            Console.WriteLine(value);
        Console.ReadLine();
    }
}