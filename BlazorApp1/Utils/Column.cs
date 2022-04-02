namespace BlazorApp1.Utils
{
    public class Column
    {
        public string ColumnName { get; set; }
        public string PropertyName { get; set; } = null;
        public System.Reflection.PropertyInfo Property { get; private set; }
        public string Style { get; set; }
        public void SetProperty(Type t)
        {
            Property = t.GetProperty(PropertyName ?? ColumnName);
        }
    }
}
