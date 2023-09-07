using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace WorkerServiceExample.Data.Config
{
    public class SnakeCaseNamingConvention : INamingConvention
    {
        string INamingConvention.SeparatorCharacter => throw new NotImplementedException();

        public string ConvertName(string name)
        {
            return name.ToSnakeCase();
        }

        public string ConvertColumnName(string name)
        {
            return name.ToSnakeCase();
        }

        public string ConvertPropertyName(string name)
        {
            return name.ToSnakeCase();
        }

        public string ConvertTypeName(string name)
        {
            return name.ToSnakeCase();
        }

        string[] INamingConvention.Split(string input)
        {
            throw new NotImplementedException();
        }
    }

    public static class StringExtensions
    {
        public static string ToSnakeCase(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            var sb = new StringBuilder();
            bool lastWasUnderscore = false;

            foreach (var c in str)
            {
                if (char.IsUpper(c))
                {
                    if (!lastWasUnderscore && sb.Length > 0)
                    {
                        sb.Append("_");
                    }

                    sb.Append(char.ToLower(c));
                    lastWasUnderscore = false;
                }
                else if (c == '_')
                {
                    if (lastWasUnderscore)
                    {
                        continue;
                    }

                    sb.Append(c);
                    lastWasUnderscore = true;
                }
                else
                {
                    sb.Append(c);
                    lastWasUnderscore = false;
                }
            }

            return sb.ToString();
        }
    }
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder UseSnakeCaseNamingConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                }
            }

            return modelBuilder;
        }
    }
}
