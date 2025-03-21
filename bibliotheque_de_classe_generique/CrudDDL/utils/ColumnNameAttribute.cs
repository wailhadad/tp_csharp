namespace CrudDDL.utils;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class ColumnNameAttribute : Attribute
{
    private string _columnName;

    public ColumnNameAttribute(string ColumnName)
    {
        column_Name = ColumnName.Trim();
    }

    public string column_Name
    {
        get { return _columnName; }
        set { _columnName = value; }
    }
}