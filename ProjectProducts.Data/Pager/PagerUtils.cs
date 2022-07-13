namespace ProjectProducts.Data.Pager
{
    public class PagerUtils
    {
        public static int PageSize(string size)
        {
            return (string.IsNullOrEmpty(size)) ? 100 : int.Parse(size);
        }

        public static int PageNumber(string page)
        {
            return (string.IsNullOrEmpty(page)) ? 1 : int.Parse(page);
        }

        public static string OrderByField(bool? descProductName, bool? descCategoryName)
        {
            if (descProductName != null && descCategoryName != null)
            {
                return $"NameProduct {((bool)descProductName ? "desc" : "asc")} ,Categories.NameCategory {((bool)descCategoryName ? "desc" : "asc")} ";
            }
            else
            {
                if (descProductName != null)
                {
                    return $"NameProduct {((bool)descProductName ? "desc" : "asc")} ";
                }
                else if (descCategoryName != null)
                {
                    return $"Categories.NameCategory {((bool)descCategoryName ? "desc" : "asc")}";
                }
                else
                {
                    return $"Id_Product  asc";
                }
            }
        }
    }
}
